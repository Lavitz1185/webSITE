using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using webSITE.Configuration;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using webSITE.Models;
using webSITE.Areas.Dashboard.Models.FotoController;
using webSITE.Utilities;
using webSITE.DataAccess.Data;
using webSITE.Domain.Exceptions.Abstraction;
using webSITE.Domain.Exceptions;

namespace webSITE.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, ADMIN, SuperAdmin, SUPERADMIN")]
    public class FotoController : Controller
    {
        private readonly PhotoFileSettings _photoFileSettings;

        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly IRepositoriMahasiswaFoto _repositoriMahasiswaFoto;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly INotificationService _notificationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FotoController> _logger;

        public FotoController(IRepositoriFoto repositoriFoto,
            IRepositoriKegiatan repositoriKegiatan,
            IMapper mapper,
            IRepositoriMahasiswa repositoriMahasiswa,
            IWebHostEnvironment webHostEnvironment,
            IRepositoriMahasiswaFoto repositoriMahasiswaFoto,
            INotificationService notificationService,
            IOptions<PhotoFileSettings> options,
            IUnitOfWork unitOfWork,
            ILogger<FotoController> logger)
        {
            _photoFileSettings = options.Value;
            _repositoriFoto = repositoriFoto;
            _repositoriKegiatan = repositoriKegiatan;
            _mapper = mapper;
            _repositoriMahasiswa = repositoriMahasiswa;
            _webHostEnvironment = webHostEnvironment;
            _repositoriMahasiswaFoto = repositoriMahasiswaFoto;
            _notificationService = notificationService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IActionResult> DetailFoto(int? id, int? idKegiatan)
        {
            var daftarSemuaFoto = await _repositoriFoto.GetAllWithDetail();

            daftarSemuaFoto ??= new List<Foto>();

            var daftarFotoAlbum = daftarSemuaFoto.Where(f => f.IdKegiatan == idKegiatan).ToList();

            if (daftarFotoAlbum.Count == 0)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Info,
                    Title = "Detail Foto",
                    Message = $"Album tidak memiliki foto"
                });
                return RedirectToAction(nameof(Album), new { idKegiatan });
            }

            id = id ?? daftarFotoAlbum[0].Id;

            var fotoAktif = daftarFotoAlbum.Find(f => f.Id == id);

            ViewData["SelectedIndex"] = daftarFotoAlbum.IndexOf(fotoAktif);
            ViewData["IdKegiatan"] = idKegiatan;

            if (idKegiatan is not null)
                ViewData["NamaKegiatan"] = (await _repositoriKegiatan.Get(idKegiatan.Value))?.NamaKegiatan;
            else
                ViewData["NamaKegiatan"] = "Lain - Lain";

            return View(daftarFotoAlbum);
        }

        public async Task<IActionResult> Album(int? idKegiatan, string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Foto", new { Area = "Dashboard" });

            ViewData["ReturnUrl"] = returnUrl;

            if (idKegiatan == null)
            {
                var daftarFotoTanpaKegiatan = await _repositoriFoto.GetAll();

                if (daftarFotoTanpaKegiatan == null || daftarFotoTanpaKegiatan.Count() == 0)
                    return View(new AlbumVM
                    {
                        NamaKegiatan = "Lain - Lain"
                    });

                daftarFotoTanpaKegiatan = daftarFotoTanpaKegiatan
                    .Where(f => f.IdKegiatan == null)
                    .OrderBy(f => f.Tanggal)
                    .ToList();

                return View(new AlbumVM
                {
                    NamaKegiatan = "Lain - Lain",
                    Tanggal = daftarFotoTanpaKegiatan.First().Tanggal,
                    DaftarFoto = daftarFotoTanpaKegiatan.ToList()
                });
            }

            var kegiatan = await _repositoriKegiatan.Get(idKegiatan ?? 0);

            if (kegiatan == null)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Album Foto",
                    Message = $"Kegiatan dengan Id = {idKegiatan} tidak ada"
                });
                return Redirect(returnUrl);
            }

            var daftarFoto = await _repositoriFoto.GetAllByKegiatan(kegiatan.Id);

            daftarFoto ??= new List<Foto>();

            var model = new AlbumVM
            {
                IdKegiatan = idKegiatan,
                NamaKegiatan = kegiatan.NamaKegiatan,
                Tanggal = kegiatan.Tanggal,
                DaftarFoto = daftarFoto
                    .OrderBy(f => f.Tanggal)
                    .ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Index(string? view)
        //view = "album"/"list"
        {
            view ??= "album";
            ViewData["view"] = view;

            var daftarFoto = await _repositoriFoto.GetAllWithDetail();
            var daftarKegiatan = await _repositoriKegiatan.GetAllWithDetail();

            List<AlbumVM> viewModel = new List<AlbumVM>();

            foreach (var kegiatan in daftarKegiatan)
            {
                if (kegiatan.DaftarFoto != null && kegiatan.DaftarFoto.Count > 0)
                {
                    var fotoThumbnail = kegiatan.DaftarFoto.OrderBy(f => f.Tanggal).First();
                    viewModel.Add(new AlbumVM
                    {
                        NamaKegiatan = kegiatan.NamaKegiatan,
                        IdKegiatan = kegiatan.Id,
                        IdThumbnail = fotoThumbnail.Id,
                        JumlahFoto = kegiatan.DaftarFoto.Count(),
                        Tanggal = fotoThumbnail.Tanggal,
                        DaftarFoto = daftarFoto.Where(f => f.IdKegiatan == kegiatan.Id).ToList(),
                    });
                }
                else
                    viewModel.Add(new AlbumVM
                    {
                        NamaKegiatan = kegiatan.NamaKegiatan,
                        IdKegiatan = kegiatan.Id,
                        JumlahFoto = 0
                    });
            }

            var fotoTanpaKegiatan = daftarFoto
                .Where(f => f.IdKegiatan == null)
                .OrderBy(f => f.Tanggal)
                .ToList();

            if (fotoTanpaKegiatan != null && fotoTanpaKegiatan.Count > 0)
            {
                viewModel.Add(new AlbumVM
                {
                    NamaKegiatan = "Lain - Lain",
                    IdThumbnail = fotoTanpaKegiatan.First().Id,
                    JumlahFoto = fotoTanpaKegiatan.Count,
                    Tanggal = fotoTanpaKegiatan.First().Tanggal,
                    DaftarFoto = fotoTanpaKegiatan,
                });
            }
            else
            {
                viewModel.Add(new AlbumVM
                {
                    NamaKegiatan = "Lain -Lain",
                    JumlahFoto = 0
                });
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Tambah(int? idKegiatan, bool showIdKegiatan = true)
        {
            var listMahasiswa = await _repositoriMahasiswa.GetAll();

            var daftarMahasiswaTambahFotoVM = new List<MahasiswaTambahFotoVM>();
            if (listMahasiswa is not null)
                daftarMahasiswaTambahFotoVM = listMahasiswa.Select(m => new MahasiswaTambahFotoVM
                {
                    Id = m.Id,
                    NamaLengkap = m.NamaLengkap,
                    DalamFoto = false
                }).ToList();

            ViewData["showIdKegiatan"] = showIdKegiatan;

            return View(new TambahFotoVM
            {
                Tanggal = DateTime.Now,
                DaftarMahasiswaTambahFotoVM = daftarMahasiswaTambahFotoVM,
                IdKegiatan = idKegiatan
            });
        }

        [HttpPost]
        public async Task<IActionResult> Tambah(TambahFotoVM tambahFotoVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Perbaiki form!");
                return View(tambahFotoVM);
            }

            var formFileContent = await FileHelpers.ProcessFormFile<TambahFotoVM>(
                tambahFotoVM.FotoFormFile,
                ModelState,
                _photoFileSettings.PermittedExtension,
                _photoFileSettings.FileSizeLimit);

            if (!ModelState.IsValid)
            {
                return View(tambahFotoVM);
            }

            var trustedFileNameForFileStorage = $"{Path.GetRandomFileName()}{Guid.NewGuid()}{Path.GetExtension(tambahFotoVM.FotoFormFile.FileName)}";
            var filePath = Path.Combine(
                _photoFileSettings.StoredFilesPath, trustedFileNameForFileStorage);

            Foto newFoto = _mapper.Map<Foto>(tambahFotoVM);
            newFoto.PhotoPath = filePath;

            var idMahasiswaDalamFoto = tambahFotoVM.DaftarMahasiswaTambahFotoVM
                .Where(x => x.DalamFoto == true)
                .Select(x => x.Id).ToList();

            var daftarMahasiswa = idMahasiswaDalamFoto.Select(async id => await _repositoriMahasiswa.Get(id))
                .Select(t => t.Result);

            newFoto.DaftarMahasiswa = daftarMahasiswa.ToList();

            try
            {
                await _repositoriFoto.Add(newFoto);

                using (var fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + filePath))
                {
                    await fileStream.WriteAsync(formFileContent);
                }

                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(
                    new ToastrNotification
                    {
                        Type = ToastrNotificationType.Success,
                        Title = "Tambah Foto Sukses",
                        Message = "Foto berhasil ditambahkan"
                    });
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Tambah Foto Gagal",
                    Message = ex.Message,
                });

                _logger.LogError("Tambah Foto. Domain Exception {0}", ex.ToString());
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tambahFotoVM);
            }
            catch (Exception ex) 
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Tambah Foto Gagal"
                });

                _logger.LogError("Tambah Foto. Exception {0}", ex.ToString());
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tambahFotoVM);
            }

            return RedirectToAction(nameof(Album), new { idKegiatan = tambahFotoVM.IdKegiatan });
        }

        [HttpPost]
        public async Task<IActionResult> PindahFoto(int? idKegiatan, int idFoto)
        {
            var returnUrl = Url.Action(nameof(Album), new { idKegiatan }) ?? "/";

            try
            {
                if (idKegiatan is null)
                {
                    var foto = await _repositoriFoto.Get(idFoto);

                    if (foto is null)
                        throw new FotoNotFoundException(idFoto);

                    foto.IdKegiatan = null;
                    await _repositoriFoto.Update(foto);
                }
                else
                {
                    await _repositoriKegiatan.AddFoto(idFoto, idKegiatan.Value);
                }

                await _unitOfWork.SaveChangesAsync();

                string namaAlbum = "Lain - Lain";

                if(idKegiatan is not null)
                {
                    var kegiatan = await _repositoriKegiatan.Get(idKegiatan.Value);
                    namaAlbum = kegiatan!.NamaKegiatan;
                }

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Pindah Foto Berhasil",
                    Message = $"Foto dengan id {idFoto} berhasil dipindah ke kegiatan {namaAlbum}"
                });
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Pindah Foto Gagal",
                    Message = ex.Message,
                });

                _logger.LogError("Pindah Foto. Domain Exception {0}", ex.ToString());
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Pindah Foto Gagal",
                    Message = "",
                });

                _logger.LogError("Pindah Foto. Domain Exception {0}", ex.ToString());
            }

            return Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Action("Index");

            try
            {
                var foto = await _repositoriFoto.Get(id);

                if (foto is not null && System.IO.File.Exists(foto.PhotoPath))
                {
                    System.IO.File.Delete(_webHostEnvironment.WebRootPath + foto.PhotoPath);
                }

                await _repositoriFoto.Delete(id);
                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(
                new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Hapus Foto Sukses",
                    Message = $"Foto dengan id {id} berhasil dihapus"
                });

                _logger.LogInformation("Delete. Foto Id {0} terhapus", id);
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(
                    new ToastrNotification
                    {
                        Type = ToastrNotificationType.Error,
                        Title = "Hapus Foto Gagal",
                        Message = ex.Message
                    });

                _logger.LogError("Delete. Domain Exception : {0}", ex.ToString());
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(
                    new ToastrNotification
                    {
                        Type = ToastrNotificationType.Error,
                        Title = "Hapus Foto Gagal",
                        Message = ""
                    });

                _logger.LogError("Delete. Exception : {0}", ex.ToString());
            }

            return Redirect(returnUrl!);
        }
    }
}
