using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using webSITE.Areas.Dashboard.Models.FotoController;
using webSITE.Areas.Dashboard.Models.KegiatanController;
using webSITE.Configuration;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Domain.Abstractions;
using webSITE.Domain.Exceptions.FotoExceptions;
using webSITE.Domain.Exceptions.MahasiswaExceptions;
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
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly INotificationService _notificationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FotoController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FotoController(
            IRepositoriFoto repositoriFoto,
            IRepositoriMahasiswa repositoriMahasiswa,
            IWebHostEnvironment webHostEnvironment,
            INotificationService notificationService,
            IOptions<PhotoFileSettingsOptions> options,
            IUnitOfWork unitOfWork,
            ILogger<FotoController> logger)
        {
            _photoFileSettings = options.Value;
            _repositoriFoto = repositoriFoto;
            _repositoriMahasiswa = repositoriMahasiswa;
            _notificationService = notificationService;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var daftarFoto = await _repositoriFoto.GetAllWithMahasiswa();
            daftarFoto = daftarFoto?
                .OrderByDescending(x => x.AddedAt)
                .ToList();

            return View(daftarFoto);
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

                    if (mahasiswa is null) throw new MahasiswaNotFoundException(id);

                    foto.AddMahasiswa(mahasiswa);
                }

                _repositoriFoto.Add(foto);

                await _unitOfWork.SaveChangesAsync();

                if (isJson) return Ok(foto.Id);
                else
                {
                    _notificationService.AddNotification(new ToastrNotification
                    {
                        Type = ToastrNotificationType.Success,
                        Title = "Tambah Foto Sukses"
                    });
                    return Redirect(returnUrl!);
                }
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
        public async Task<IActionResult> Delete(int id)
        {
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

                _logger.LogInformation("Delete. Foto Id {@id} terhapus", id);
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

            return RedirectToAction(nameof(Index));
        }
    }
}
