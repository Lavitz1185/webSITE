using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using webSITE.Areas.Dashboard.Models.FotoController;
using webSITE.Configuration;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Domain.Abstractions;
using webSITE.Domain.Exceptions;
using webSITE.Models;
using webSITE.Services.Contracts;
using webSITE.Utilities;

namespace webSITE.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, ADMIN, SuperAdmin, SUPERADMIN")]
    public class FotoController : Controller
    {
        private readonly PhotoFileSettingsOptions _photoFileSettings;
        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly INotificationService _notificationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FotoController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FotoController(IRepositoriFoto repositoriFoto,
            IRepositoriKegiatan repositoriKegiatan,
            IMapper mapper,
            IRepositoriMahasiswa repositoriMahasiswa,
            IWebHostEnvironment webHostEnvironment,
            INotificationService notificationService,
            IOptions<PhotoFileSettingsOptions> options,
            IUnitOfWork unitOfWork,
            ILogger<FotoController> logger)
        {
            _photoFileSettings = options.Value;
            _repositoriFoto = repositoriFoto;
            _repositoriKegiatan = repositoriKegiatan;
            _repositoriMahasiswa = repositoriMahasiswa;
            _notificationService = notificationService;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Album(int? idKegiatan, string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Foto", new { Area = "Dashboard" });

            ViewData["ReturnUrl"] = returnUrl;

            if (idKegiatan is null)
            {
                var daftarFotoTanpaKegiatan = await _repositoriFoto.GetAllWithKegiatan();

                if (daftarFotoTanpaKegiatan is null || daftarFotoTanpaKegiatan.Count == 0)
                    return View(new AlbumVM
                    {
                        NamaKegiatan = "Lain - Lain"
                    });

                daftarFotoTanpaKegiatan = daftarFotoTanpaKegiatan
                    .Where(f => f.DaftarKegiatan.Count == 0)
                    .OrderBy(f => f.AddedAt)
                    .ToList();

                return View(new AlbumVM
                {
                    NamaKegiatan = "Lain - Lain",
                    Tanggal = daftarFotoTanpaKegiatan.First().AddedAt,
                    DaftarFoto = daftarFotoTanpaKegiatan.ToList()
                });
            }

            var kegiatan = await _repositoriKegiatan.GetWithDetail(idKegiatan.Value);

            if (kegiatan is null) return NotFound();

            var model = new AlbumVM
            {
                IdKegiatan = idKegiatan,
                NamaKegiatan = kegiatan.NamaKegiatan,
                Tanggal = kegiatan.Tanggal,
                DaftarFoto = kegiatan.DaftarFoto
                    .OrderBy(f => f.AddedAt)
                    .ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Index(string? view)
        //view = "album"/"list"
        {
            view ??= "album";
            ViewData["view"] = view;

            var daftarFoto = (await _repositoriFoto.GetAllWithKegiatan()) ?? new();
            var daftarKegiatan = (await _repositoriKegiatan.GetAllWithDetail()) ?? new();

            List<AlbumVM> viewModel = new List<AlbumVM>();

            foreach (var kegiatan in daftarKegiatan)
            {
                if (kegiatan.DaftarFoto.Count > 0)
                {
                    var fotoThumbnail = kegiatan.DaftarFoto.OrderBy(f => f.AddedAt).First();
                    viewModel.Add(new AlbumVM
                    {
                        NamaKegiatan = kegiatan.NamaKegiatan,
                        IdKegiatan = kegiatan.Id,
                        IdThumbnail = fotoThumbnail.Id,
                        JumlahFoto = kegiatan.DaftarFoto.Count(),
                        Tanggal = fotoThumbnail.AddedAt,
                        DaftarFoto = kegiatan.DaftarFoto.ToList(),
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
                .Where(f => f.DaftarKegiatan.Count == 0)
                .OrderBy(f => f.AddedAt)
                .ToList();

            if (fotoTanpaKegiatan.Count > 0)
            {
                viewModel.Add(new AlbumVM
                {
                    NamaKegiatan = "Lain - Lain",
                    IdThumbnail = fotoTanpaKegiatan.First().Id,
                    JumlahFoto = fotoTanpaKegiatan.Count,
                    Tanggal = fotoTanpaKegiatan.First().AddedAt,
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
        public IActionResult Tambah(string? returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl ?? Url.Action(nameof(Index));
            return View(new TambahVM());
        }

        [HttpPost]
        public async Task<IActionResult> Tambah(TambahVM tambahVM, string? returnUrl = null, bool isJson = false)
        {
            returnUrl ??= Url.Action(nameof(Index));

            //Validasi
            if (!ModelState.IsValid)
                if (isJson) return BadRequest(ModelState);
                else return View(tambahVM);

            var fileFormContent = await FileHelpers.ProcessFormFile<TambahVM>(
                tambahVM.FormFile,
                ModelState,
                _photoFileSettings.PermittedExtension,
                _photoFileSettings.FileSizeLimit);

            if (!ModelState.IsValid)
                if (isJson) return BadRequest(ModelState);
                else return View(tambahVM);

            //Simpan ke database
            try
            {
                var fileName = $"{Path.GetRandomFileName()}{Path.GetExtension(tambahVM.FormFile.FileName)}";
                var pathFile = $"{_webHostEnvironment.WebRootPath}/{_photoFileSettings.StoredFilesPath}{fileName}";

                using (var fileStream = System.IO.File.Create(pathFile))
                {
                    await fileStream.WriteAsync(fileFormContent);
                }

                var foto = new Foto { Id = 0, Path = pathFile };

                foreach (var id in tambahVM.DaftarIdMahasiswa)
                {
                    var mahasiswa = await _repositoriMahasiswa.Get(id);

                    if(mahasiswa is null) throw new MahasiswaNotFoundException(id);

                    foto.AddMahasiswa(mahasiswa);
                }

                _repositoriFoto.Add(foto);

                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Tambah Foto Sukses"
                });

                if (isJson) return Ok(foto.Id);
                else return Redirect(returnUrl!);
            }
            catch (MahasiswaNotFoundException ex)
            {
                ModelState.AddModelError(nameof(TambahVM.DaftarIdMahasiswa), ex.Message);

                if (isJson) return BadRequest(ModelState);
                else return View(tambahVM);
            }
            catch (FotoAlreadyHaveMahasiswaException ex)
            {
                ModelState.AddModelError(nameof(TambahVM.DaftarIdMahasiswa), ex.Message);

                if (isJson) return BadRequest(ModelState);
                else return View(tambahVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Simpan file foto gagal. Message : {@message} TimeStamp : {@timeStamp}",
                    ex.Message, DateTime.Now);
                ModelState.AddModelError(nameof(TambahVM.FormFile), "Simpan file gagal");

                if (isJson) return BadRequest(ModelState);
                else return View(tambahVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Action(nameof(Index));

            try
            {
                var foto = await _repositoriFoto.Get(id);

                if (foto is null) return NotFound();

                if (System.IO.File.Exists(foto.Path))
                {
                    System.IO.File.Delete(foto.Path);
                }

                await _repositoriFoto.Delete(id);
                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                    {
                        Type = ToastrNotificationType.Success,
                        Title = "Hapus Foto Sukses",
                        Message = $"Foto dengan id {id} berhasil dihapus"
                    }
                );

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
