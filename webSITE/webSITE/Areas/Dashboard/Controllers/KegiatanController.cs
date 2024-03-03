using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using webSITE.Areas.Dashboard.Models.KegiatanController;
using webSITE.Areas.Dashboard.Models.Shared;
using webSITE.Configuration;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Utilities;

namespace webSITE.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, ADMIN")]
    public class KegiatanController : Controller
    {
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IRepositoriPesertaKegiatan _repositoriPesertaKegiatan;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IRepositoriMahasiswaFoto _repositoriMahasiswaFoto;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<KegiatanController> _logger;

        private readonly PhotoFileSettings _photoFileSettings;

        public KegiatanController(
            IRepositoriKegiatan repositoriKegiatan,
            IRepositoriPesertaKegiatan pesertaKegiatan,
            IRepositoriMahasiswa repositoriMahasiswa,
            IRepositoriFoto repositoriFoto,
            IRepositoriMahasiswaFoto repositoriMahasiswaFoto,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment,
            ILogger<KegiatanController> logger,
            IOptions<PhotoFileSettings> options
            )
        {
            _repositoriKegiatan = repositoriKegiatan;
            _repositoriPesertaKegiatan = pesertaKegiatan;
            _repositoriMahasiswa = repositoriMahasiswa;
            _repositoriFoto = repositoriFoto;
            _repositoriMahasiswaFoto = repositoriMahasiswaFoto;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _photoFileSettings = options.Value;
        }

        public async Task<IActionResult> Index()
        {
            var listKegiatan = (await _repositoriKegiatan.GetAll()).ToList();

            return View(listKegiatan);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var kegiatan = await _repositoriKegiatan.GetWithDetail(id);

            return View(kegiatan);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repositoriKegiatan.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult TambahKegiatan()
        {
            return View(new TambahKegiatanVM
            {
                Tanggal = DateTime.Now,
                JumlahHari = 1
            });
        }

        [HttpPost]
        public async Task<IActionResult> TambahKegiatan(TambahKegiatanVM tambahKegiatanVM)
        {
            //Validasi
            var daftarKegiatanDB = await _repositoriKegiatan.GetAllByNamaKegiatan(tambahKegiatanVM.NamaKegiatan);
            if (daftarKegiatanDB != null && daftarKegiatanDB.Count > 0)
            {
                if (daftarKegiatanDB.Any(k => k.Tanggal.Date == tambahKegiatanVM.Tanggal.Date))
                {
                    ModelState.AddModelError("NamaKegiatan", "Kegiatan dengan nama dan tanggal yang sama sudah ada");
                    return View(tambahKegiatanVM);
                }
            }

            var kegiatan = _mapper.Map<Kegiatan>(tambahKegiatanVM);
            kegiatan.Id = 0;
            kegiatan = await _repositoriKegiatan.Create(kegiatan);
            if (kegiatan == null)
            {
                ModelState.AddModelError(string.Empty, "Error menambahkan data, silahkan hubungi admin");
                return View(tambahKegiatanVM);
            }

            return RedirectToAction(
                "TambahFoto",
                new
                {
                    idKegiatan = kegiatan.Id,
                    nextUrl = Url.ActionLink("TambahMahasiswa", "Kegiatan",
                                  new { Area = "Dashboard", idKegiatan = kegiatan.Id })
                }
            );
        }

        public async Task<IActionResult> TambahFoto(int idKegiatan, string? nextUrl)
        {
            nextUrl = nextUrl ?? Url.ActionLink("Index", "Kegiatan", new { Area = "Dashboard" });

            var kegiatan = await _repositoriKegiatan.Get(idKegiatan);

            if (kegiatan == null)
                return View(new TambahFotoDiKegiatanVM());

            var daftarFotoTanpaKegiatan = (await _repositoriFoto.GetAll())
                .Where(f => f.IdKegiatan == null)
                .Select(f => new FotoTambahFotoDiKegiatanVM { IdFoto = f.Id, DalamKegiatan = false })
                .ToList();

            var daftarMahasiswa = (await _repositoriMahasiswa.GetAll())
                .Select(m => new MahasiswaIncludeVM
                {
                    IdMahasiswa = m.Id,
                    NamaLengkap = m.NamaLengkap,
                    Included = false
                })
                .ToList();

            return View(new TambahFotoDiKegiatanVM
            {
                IdKegiatan = idKegiatan,
                NextUrl = nextUrl,
                FotoTanpaKegiatan = daftarFotoTanpaKegiatan,
                FotoBaru = new FotoBaruTambahFotoDiKegiatanVM
                {
                    Tanggal = kegiatan.Tanggal,
                    DaftarMahasiswa = daftarMahasiswa
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> TambahFoto(TambahFotoDiKegiatanVM tambahFotoVM, bool fotoBaru)
        {
            tambahFotoVM.FotoTanpaKegiatan = tambahFotoVM.FotoTanpaKegiatan ?? new List<FotoTambahFotoDiKegiatanVM>();
            ModelState.Clear();

            if (fotoBaru)
            {
                try
                {
                    if (tambahFotoVM.FotoBaru.FotoFormFile == null)
                    {
                        ModelState.AddModelError("FotoBaru.FotoFormFile", "File Foto Harus Diisi!");
                        return View(tambahFotoVM);
                    }

                    var formFileContent = await FileHelpers.ProcessFormFile<TambahFotoDiKegiatanVM>(
                        tambahFotoVM.FotoBaru.FotoFormFile,
                        ModelState,
                        _photoFileSettings.PermittedExtension,
                        _photoFileSettings.FileSizeLimit);

                    if (!ModelState.IsValid)
                    {
                        return View(tambahFotoVM);
                    }

                    var trustedFileNameForFileStorage = $"{Path.GetRandomFileName()}{Guid.NewGuid()}{Path.GetExtension(tambahFotoVM.FotoBaru.FotoFormFile.FileName)}";
                    var filePath = Path.Combine(
                        _photoFileSettings.StoredFilesPath, trustedFileNameForFileStorage);

                    Foto newFoto = new Foto
                    {
                        Tanggal = tambahFotoVM.FotoBaru.Tanggal,
                        IdKegiatan = null
                    };

                    newFoto.PhotoPath = filePath;

                    var idMahasiswaDalamFoto = tambahFotoVM.FotoBaru.DaftarMahasiswa
                        .Where(x => x.Included == true)
                        .Select(x => x.IdMahasiswa).ToList();

                    newFoto = await _repositoriFoto.Create(newFoto);

                    if (newFoto == null)
                    {
                        ModelState.AddModelError(string.Empty, "Error menambahkan foto");
                        return View(tambahFotoVM);
                    }

                    using (var fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + filePath))
                    {
                        await fileStream.WriteAsync(formFileContent);
                    }

                    foreach (var id in idMahasiswaDalamFoto)
                        await _repositoriMahasiswaFoto.Create(id, newFoto.Id);

                    tambahFotoVM.FotoBaru.FotoFormFile = null;
                    tambahFotoVM.FotoBaru.DaftarMahasiswa = (await _repositoriMahasiswa.GetAll())
                        .Select(m => new MahasiswaIncludeVM
                        {
                            IdMahasiswa = m.Id,
                            NamaLengkap = m.NamaLengkap,
                            Included = false
                        })
                        .ToList();
                    tambahFotoVM.FotoBaru.Tanggal = default;

                    tambahFotoVM.FotoTanpaKegiatan.Add(new FotoTambahFotoDiKegiatanVM { IdFoto = newFoto.Id, DalamKegiatan = true });
                }
                catch (Exception ex)
                {
                    _logger.LogError("Tambah Foto Baru", ex);
                }

                return View(tambahFotoVM);
            }
            else
            {
                var daftarIdFoto = tambahFotoVM.FotoTanpaKegiatan
                    .Where(f => f.DalamKegiatan == true)
                    .Select(f => f.IdFoto)
                    .ToList();

                foreach (var id in daftarIdFoto)
                {
                    var result = await _repositoriKegiatan.AddFoto(id, tambahFotoVM.IdKegiatan);
                    if (result == null)
                    {
                        ModelState.AddModelError(string.Empty, $"Gagal menambah foto dengan id {id} pada kegiatan");
                        tambahFotoVM.FotoTanpaKegiatan = (await _repositoriFoto.GetAll())
                            .Where(f => f.IdKegiatan == null)
                            .Select(f => new FotoTambahFotoDiKegiatanVM { IdFoto = f.Id, DalamKegiatan = false })
                            .ToList();

                        return View(tambahFotoVM);
                    }
                }

                return Redirect(tambahFotoVM.NextUrl);
            }
        }

        public async Task<IActionResult> TambahMahasiswa(int idKegiatan, string? nextUrl)
        {
            nextUrl = nextUrl ?? Url.Action("Index");

            var kegiatanDB = await _repositoriKegiatan.GetWithDetail(idKegiatan);

            var daftarMahasiswa = await _repositoriMahasiswa.GetAll();

            var tambahMahasiswaDiKegiatanVM = new TambahMahasiswaDiKegiatanVM
            {
                IdKegiatan = idKegiatan,
                NamaKegiatan = kegiatanDB.NamaKegiatan,
                Tanggal = kegiatanDB.Tanggal,
                NextUrl = nextUrl,
                NamaPesertaKegiatan = kegiatanDB.DaftarMahasiswa
                    .Select(m => m.NamaLengkap)
                    .ToList(),
                DaftarPesertaBaru = daftarMahasiswa
                    .Where(m => !kegiatanDB.DaftarMahasiswa.Any(x => x.Id == m.Id))
                    .Select(m => new MahasiswaIncludeVM
                    {
                        IdMahasiswa = m.Id,
                        NamaLengkap = m.NamaLengkap,
                        Included = false
                    }).ToList()
            };

            return View(tambahMahasiswaDiKegiatanVM);
        }

        [HttpPost]
        public async Task<IActionResult> TambahMahasiswa(TambahMahasiswaDiKegiatanVM tambahMahasiswaVM)
        {
            if (tambahMahasiswaVM.DaftarPesertaBaru == null || tambahMahasiswaVM.DaftarPesertaBaru.Count == 0)
                return Redirect(tambahMahasiswaVM.NextUrl);

            List<string> idMahasiswaDalamKegiatan = tambahMahasiswaVM.DaftarPesertaBaru
                .Where(m => m.Included == true)
                .Select(m => m.IdMahasiswa)
                .ToList();

            if (idMahasiswaDalamKegiatan is null || idMahasiswaDalamKegiatan.Count == 0)
                return Redirect(tambahMahasiswaVM.NextUrl);

            foreach (var idMahasiswa in idMahasiswaDalamKegiatan)
                await _repositoriPesertaKegiatan.Create(idMahasiswa, tambahMahasiswaVM.IdKegiatan);

            return Redirect(tambahMahasiswaVM.NextUrl);
        }

        public async Task<IActionResult> EditKegiatan(int id)
        {
            var kegiatan = await _repositoriKegiatan.GetWithDetail(id);

            if (kegiatan == null)
                return RedirectToAction("Index");

            var model = new EditKegiatanVM
            {
                Id = kegiatan.Id,
                NamaKegiatan = kegiatan.NamaKegiatan,
                Tanggal = kegiatan.Tanggal,
                JumlahHari = kegiatan.JumlahHari,
                TempatKegiatan = kegiatan.TempatKegiatan,
                Keterangan = kegiatan.Keterangan,
                DaftarFoto = kegiatan.DaftarFoto?.ToList() ?? new List<Foto>(),
                DaftarMahasiswa = kegiatan.DaftarMahasiswa.ToList() ?? new List<Mahasiswa>()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditKegiatan(EditKegiatanVM editKegiatanVM)
        {
            //Validasi
            var kegiatanNamaSama = await _repositoriKegiatan.GetAllByNamaKegiatan(editKegiatanVM.NamaKegiatan);

            if (kegiatanNamaSama.Any(k => k.Tanggal.Date == editKegiatanVM.Tanggal.Date))
            {
                var kegiatanDetail = await _repositoriKegiatan.GetWithDetail(editKegiatanVM.Id);

                editKegiatanVM.DaftarFoto = kegiatanDetail.DaftarFoto?.ToList();
                editKegiatanVM.DaftarMahasiswa = kegiatanDetail.DaftarMahasiswa.ToList();

                ModelState.AddModelError<EditKegiatanVM>(k => k.NamaKegiatan,
                    "Kegiatan dengan nama dan tanggal yang sama sudah ada");
                return View(editKegiatanVM);
            }

            var result = await _repositoriKegiatan.Update(new Kegiatan
            {
                Id = editKegiatanVM.Id,
                NamaKegiatan = editKegiatanVM.NamaKegiatan,
                Tanggal = editKegiatanVM.Tanggal,
                TempatKegiatan = editKegiatanVM.TempatKegiatan,
                JumlahHari = editKegiatanVM.JumlahHari,
                Keterangan = editKegiatanVM.Keterangan
            });

            if (result == null)
            {
                var kegiatanDetail = await _repositoriKegiatan.GetWithDetail(editKegiatanVM.Id);

                editKegiatanVM.DaftarFoto = kegiatanDetail.DaftarFoto?.ToList();
                editKegiatanVM.DaftarMahasiswa = kegiatanDetail.DaftarMahasiswa.ToList();

                ModelState.AddModelError(string.Empty, "Error Mengubah Kegiatan");
                return View(editKegiatanVM);
            }

            return RedirectToAction("Detail", new { Id = editKegiatanVM.Id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFoto(int idKegiatan, int idFoto)
        {
            var result = await _repositoriKegiatan.RemoveFoto(idFoto, idKegiatan);

            return RedirectToAction(nameof(EditKegiatan), new { Id = idKegiatan });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMahasiswa(int idKegiatan, string idMahasiswa)
        {
            var result = await _repositoriPesertaKegiatan.Delete(idMahasiswa, idKegiatan);

            return RedirectToAction(nameof(EditKegiatan), new { Id = idKegiatan });
        }
    }
}
