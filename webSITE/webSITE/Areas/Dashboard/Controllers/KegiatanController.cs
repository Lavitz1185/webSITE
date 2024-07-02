using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using NuGet.Versioning;
using webSITE.Areas.Dashboard.Models.KegiatanController;
using webSITE.Areas.Dashboard.Models.Shared;
using webSITE.Configuration;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Domain.Exceptions.Abstraction;
using webSITE.Models;
using webSITE.Services.Contracts;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;

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
            IOptions<PhotoFileSettings> options,
            IUnitOfWork unitOfWork,
            INotificationService notificationService)
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
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var listKegiatan = await _repositoriKegiatan.GetAll();

            listKegiatan ??= new();

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
            try
            {
                await _repositoriKegiatan.Delete(id);
                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Hapus Kegiatan Sukses"
                });
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Kegiatan Gagal",
                    Message = ex.Message,
                });
                _logger.LogError("Delete. Exception : {0}", ex.ToString());
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Kegiatan Gagal",
                });
                _logger.LogError("Delete. Exception : {0}", ex.ToString());
            }

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
            var kegiatan = _mapper.Map<Kegiatan>(tambahKegiatanVM);
            kegiatan.Id = 0;

            try
            {
                await _repositoriKegiatan.Add(kegiatan);
                await _unitOfWork.SaveChangesAsync();

                kegiatan = (await _repositoriKegiatan.GetAllByNamaKegiatan(kegiatan.NamaKegiatan))!
                    .Where(k => k.Tanggal == kegiatan.Tanggal).FirstOrDefault();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Tambah Kegiatan Sukses",
                    Message = "Sukses menambahkan kegiatan. Lanjutkan dengan menambahkan foto untuk kegiatan"
                });
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Tambah Kegiatan Gagal",
                    Message = ex.Message,
                });
                ModelState.AddModelError(string.Empty, $"Tambah Gagal. {ex.Message}");

                _logger.LogError("Tambah. Domain Exception : {0}", ex.ToString());
                return View(tambahKegiatanVM);
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Tambah Kegiatan Gagal"
                });
                ModelState.AddModelError(string.Empty, $"Tambah Gagal");

                _logger.LogError("Tambah. Exception : {0}", ex.ToString());
                return View(tambahKegiatanVM);
            }

            return RedirectToAction(
                "TambahFoto",
                new
                {
                    idKegiatan = kegiatan!.Id,
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
            tambahFotoVM.FotoTanpaKegiatan = tambahFotoVM.FotoTanpaKegiatan ??
                new List<FotoTambahFotoDiKegiatanVM>();

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

                    var daftarMahasiswa = idMahasiswaDalamFoto.Select(async id => await _repositoriMahasiswa.Get(id))
                        .Select(t => t.Result).ToList();

                    if (daftarMahasiswa is not null)
                        newFoto.DaftarMahasiswa = daftarMahasiswa!;

                    await _repositoriFoto.Add(newFoto);

                    using (var fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + filePath))
                    {
                        await fileStream.WriteAsync(formFileContent);
                    }

                    await _unitOfWork.SaveChangesAsync();

                    _notificationService.AddNotification(new ToastrNotification
                    {
                        Type = ToastrNotificationType.Success,
                        Title = "Tambah Foto Baru Sukses",
                        Message = "Silahkan pilih foto untuk ditambahkan ke kegiatan"
                    });

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
                catch (DomainException ex)
                {
                    _notificationService.AddNotification(new ToastrNotification
                    {
                        Type = ToastrNotificationType.Error,
                        Title = "Tambah Foto Baru Gagal",
                        Message = ex.Message,
                    });
                    _logger.LogError($"TambahFoto Gagal. Exception : {ex.ToString()}");

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                catch (Exception ex)
                {
                    _notificationService.AddNotification(new ToastrNotification
                    {
                        Type = ToastrNotificationType.Error,
                        Title = "Tambah Foto Baru Gagal"
                    });
                    _logger.LogError($"TambahFoto Gagal. Exception : {ex.ToString()}");

                    ModelState.AddModelError(string.Empty, "Terjadi error pada sistem. Silahkan hubungi admin");
                }

                return View(tambahFotoVM);
            }
            else
            {
                var daftarIdFoto = tambahFotoVM.FotoTanpaKegiatan
                    .Where(f => f.DalamKegiatan == true)
                    .Select(f => f.IdFoto)
                    .ToList();

                try
                {
                    foreach (var id in daftarIdFoto)
                    {
                        await _repositoriKegiatan.AddFoto(id, tambahFotoVM.IdKegiatan);
                    }

                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DomainException ex)
                {
                    _notificationService.AddNotification(new ToastrNotification
                    {
                        Type = ToastrNotificationType.Error,
                        Title = "Tambah Foto ke Kegiatan Gagal",
                        Message = ex.Message
                    });
                    _logger.LogError("TambahFoto. Exception : {0}", ex.ToString());

                    tambahFotoVM.FotoTanpaKegiatan = (await _repositoriFoto.GetAll())
                            .Where(f => f.IdKegiatan == null)
                            .Select(f => new FotoTambahFotoDiKegiatanVM { IdFoto = f.Id, DalamKegiatan = false })
                            .ToList();

                    return View(tambahFotoVM);
                }
                catch (Exception ex)
                {
                    _notificationService.AddNotification(new ToastrNotification
                    {
                        Type = ToastrNotificationType.Error,
                        Title = "Tambah Foto ke Kegiatan Gagal",
                    });
                    _logger.LogError("TambahFoto. Exception : {0}", ex.ToString());

                    tambahFotoVM.FotoTanpaKegiatan = (await _repositoriFoto.GetAll())
                            .Where(f => f.IdKegiatan == null)
                            .Select(f => new FotoTambahFotoDiKegiatanVM { IdFoto = f.Id, DalamKegiatan = false })
                            .ToList();

                    return View(tambahFotoVM);
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

            try
            {
                foreach (var idMahasiswa in idMahasiswaDalamKegiatan)
                    await _repositoriPesertaKegiatan.Add(idMahasiswa, tambahMahasiswaVM.IdKegiatan);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Tambah Mahasiswa ke Kegiatan gagal",
                    Message = ex.Message,
                });
                _logger.LogError("TambahMahasiswa. Exception :  {0}", ex.ToString());

                return View(tambahMahasiswaVM);
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Tambah Mahasiswa ke Kegiatan gagal",
                });
                _logger.LogError("TambahMahasiswa. Exception : {0}", ex.ToString());

                return View(tambahMahasiswaVM);
            }

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
            try
            {
                await _repositoriKegiatan.Update(new Kegiatan
                {
                    Id = editKegiatanVM.Id,
                    NamaKegiatan = editKegiatanVM.NamaKegiatan,
                    Tanggal = editKegiatanVM.Tanggal,
                    TempatKegiatan = editKegiatanVM.TempatKegiatan,
                    JumlahHari = editKegiatanVM.JumlahHari,
                    Keterangan = editKegiatanVM.Keterangan
                });

                await _unitOfWork.SaveChangesAsync();
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Edit Kegiatan Gagal",
                    Message = ex.Message,
                });
                ModelState.AddModelError(string.Empty, ex.Message);
                _logger.LogError("EditKegiatan. Exception : {0}", ex.ToString());

                var kegiatanDetail = await _repositoriKegiatan.GetWithDetail(editKegiatanVM.Id);

                editKegiatanVM.DaftarFoto = kegiatanDetail!.DaftarFoto?.ToList();
                editKegiatanVM.DaftarMahasiswa = kegiatanDetail.DaftarMahasiswa.ToList();

                return View(editKegiatanVM);
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Edit Kegiatan Gagal"
                });
                _logger.LogError("EditKegiatan. Exception : {0}", ex.ToString());

                var kegiatanDetail = await _repositoriKegiatan.GetWithDetail(editKegiatanVM.Id);

                editKegiatanVM.DaftarFoto = kegiatanDetail!.DaftarFoto?.ToList();
                editKegiatanVM.DaftarMahasiswa = kegiatanDetail.DaftarMahasiswa.ToList();

                return View(editKegiatanVM);
            }

            return RedirectToAction("Detail", new { Id = editKegiatanVM.Id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFoto(int idKegiatan, int idFoto)
        {
            try
            {
                await _repositoriKegiatan.RemoveFoto(idFoto, idKegiatan);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Foto Dari Kegiatan Gagal",
                    Message = ex.Message,
                });

                _logger.LogError("DeleteFoto. Exception : {0}", ex.ToString());
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Foto Dari Kegiatan Gagal"
                });
                _logger.LogError("DeleteFoto. Exception : {0}", ex.ToString());
            }

            return RedirectToAction(nameof(EditKegiatan), new { Id = idKegiatan });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMahasiswa(int idKegiatan, string idMahasiswa)
        {
            try
            {
                await _repositoriPesertaKegiatan.Delete(idMahasiswa, idKegiatan);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Mahasiswa Dari Kegiatan Gagal",
                    Message = ex.Message,
                });

                _logger.LogError("DeleteMahasiswa. Exception : {0}", ex.ToString());
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Mahasiswa Dari Kegiatan Gagal",
                });

                _logger.LogError("DeleteMahasiswa. Exception : {0}", ex.ToString());
            }

            return RedirectToAction(nameof(EditKegiatan), new { Id = idKegiatan });
        }
    }
}
