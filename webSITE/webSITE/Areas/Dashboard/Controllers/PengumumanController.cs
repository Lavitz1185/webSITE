using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using webSITE.Areas.Dashboard.Models.PengumumanController;
using webSITE.Configuration;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Domain.Exceptions;
using webSITE.Domain.Exceptions.Abstraction;
using webSITE.Models;
using webSITE.Services.Contracts;
using webSITE.Utilities;

namespace webSITE.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class PengumumanController : Controller
    {
        private readonly IRepositoriPengumuman _repositoriPengumuman;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;
        private readonly ILogger<PengumumanController> _logger;
        private readonly PhotoFileSettings _photoFileSettings;

        public PengumumanController(IRepositoriPengumuman repositoriPengumuman, 
            IUnitOfWork unitOfWork, 
            INotificationService notificationService, 
            ILogger<PengumumanController> logger,
            IOptionsSnapshot<PhotoFileSettings> photoFileSettingsOptions)
        {
            _repositoriPengumuman = repositoriPengumuman;
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
            _logger = logger;
            _photoFileSettings = photoFileSettingsOptions.Value;
        }

        public async Task<IActionResult> Index()
        {
            var daftarPengumuman = await _repositoriPengumuman.GetAll();

            return View(daftarPengumuman ?? new());
        }

        //Tambah Pengumuman
        public IActionResult Tambah()
        {
            return View(new TambahVM());
        }

        [HttpPost]
        public async Task<IActionResult> Tambah(TambahVM tambahVM)
        {
            if(!ModelState.IsValid) return View(tambahVM);

            //Proses file foto
            var fileFormContent = await FileHelpers.ProcessFormFile<TambahVM>(
                tambahVM.Foto,
                ModelState,
                _photoFileSettings.PermittedExtension,
                _photoFileSettings.FileSizeLimit);

            if (!ModelState.IsValid) return View(tambahVM);

            //Simpan ke database
            var pengumuman = new Pengumuman
            {
                Id = 0,
                Judul = tambahVM.Judul,
                Isi = tambahVM.Isi,
                Foto = fileFormContent,
                Tanggal = DateTime.Now,
                IsPriority = false
            };

            try
            {
                await _repositoriPengumuman.Add(pengumuman);
                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Pengumuman Berhasil Ditambahkan"
                });
            }
            catch (Exception ex) 
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Pengumuman Gagal Ditambahkan",
                    Message = "Terjadi error pada sistem"
                });
                _logger.LogError("Tambah. Exception : {0}", ex.ToString());

                return View(tambahVM);
            }

            return RedirectToAction(nameof(Index));
        }      

        //Edit Pengumuman
        public async Task<IActionResult> Edit(int id)
        {
            var pengumuman = await _repositoriPengumuman.Get(id);

            if (pengumuman == null) return NotFound();

            return View(new EditVM
            {
                Id = pengumuman.Id,
                Judul = pengumuman.Judul,
                Isi = pengumuman.Isi
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditVM editVM)
        {
            //Validasi
            if (!ModelState.IsValid) return View(editVM);

            byte[] fileFormContent = Array.Empty<byte>();
            if(editVM.FotoBaru is not null)
            {
                fileFormContent = await FileHelpers.ProcessFormFile<EditVM>(editVM.FotoBaru,
                    ModelState, _photoFileSettings.PermittedExtension,
                    _photoFileSettings.FileSizeLimit);

                if (!ModelState.IsValid) return View(editVM);
            }

            //Simpan ke database
            try
            {
                var pengumuman = await _repositoriPengumuman.Get(editVM.Id);
                if (pengumuman is null) throw new PengumumanNotFoundException(editVM.Id);

                pengumuman.Judul = editVM.Judul;
                pengumuman.Isi = editVM.Isi;

                if (editVM.FotoBaru is not null)
                    pengumuman.Foto = fileFormContent;

                await _repositoriPengumuman.Update(pengumuman);
                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Edit Pengumuman Sukse"
                });
            }
            catch(DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Edit Pengumuman Gagal",
                    Message = ex.Message
                });
                _logger.LogError("Edit. Exception : {0}", ex.ToString());

                return View(editVM);
            }
            catch(Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Edit Pengumuman Gagal",
                    Message = "Terjadi error pada sistem"
                });
                _logger.LogError("Edit. Exception : {0}", ex.ToString());

                return View(editVM);
            }

            return RedirectToAction(nameof(Index));
        }

        //Hapus Pengumuman
        [HttpPost]
        public async Task<IActionResult> Hapus(int id, string? returnUrl)
        {
            returnUrl ??= Url.Action(nameof(Index));

            try
            {
                await _repositoriPengumuman.Delete(id);
                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification{
                    Type = ToastrNotificationType.Success,
                    Title = "Hapus Pengumuman Berhasil"
                });
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Hapus Pengumuman Gagal",
                    Message = ex.Message
                });
                _logger.LogError("Hapus. Exception : {0}", ex.ToString());
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Hapus Pengumuman Gagal",
                    Message = "Terjadi masalah pada sistem"
                });
                _logger.LogError("Hapus. Exception : {0}", ex.ToString());
            }

            return Redirect(returnUrl!);
        }

        //Set Priority
        public async Task<IActionResult> Prioritas(int id, bool priority, string? returnUrl)
        {
            returnUrl ??= Url.Action(nameof(Index));

            try
            {
                var pengumuman = await _repositoriPengumuman.Get(id);

                if (pengumuman is null) throw new PengumumanNotFoundException(id);

                if (priority)
                {
                    var pengumumanPriority = await _repositoriPengumuman.GetAll();

                    if(pengumumanPriority is not null && pengumumanPriority.Count > 0)
                    {
                        pengumumanPriority = pengumumanPriority.Where(p => p.IsPriority).ToList();

                        foreach (var item in pengumumanPriority)
                        {
                            item.IsPriority = false;
                            await _repositoriPengumuman.Update(item);
                        }
                    }
                }

                pengumuman.IsPriority = priority;

                await _repositoriPengumuman.Update(pengumuman);
                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Set Prioritas Berhasil",
                    Message = $"Prioritas pengumuman berhasil di set menjadi {priority}"
                });
            }
            catch(DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Set Prioritas Pengumuman Gagal",
                    Message = ex.Message,
                });
                _logger.LogError("SetPriority. Exception {0}", ex.ToString());
            }
            catch(Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Set Prioritas Pengumuman Gagal",
                    Message = "Sistem error."
                });
                _logger.LogError("SetPriority. Exception {0}", ex.ToString());
            }

            return Redirect(returnUrl!);
        }
    }
}
