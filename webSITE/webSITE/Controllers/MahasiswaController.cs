using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Services.Contracts;
using webSITE.Models;

namespace webSITE.Controllers
{
    public class MahasiswaController : Controller
    {
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly ILogger<MahasiswaController> _logger;
        private readonly INotificationService _notificationService;

        public MahasiswaController(
            IRepositoriMahasiswa repositoriMahasiswa,
            ILogger<MahasiswaController> logger,
            INotificationService notificationService)
        {
            _repositoriMahasiswa = repositoriMahasiswa;
            _logger = logger;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var listMahasiwa = (await _repositoriMahasiswa.GetAll()).Where(m => m.StatusAkun == StatusAkun.Aktif).ToList();
            return View(listMahasiwa);
        }

        public async Task<IActionResult> Detail(string id)
        {
            if (id == null)
            {
                _logger.LogError("Mahasiswa.Detail Id null/tidak ada");

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Detail Mahasiswa",
                    Message = "Error mengambil data mahasiswa"
                });

                return RedirectToAction(nameof(Index));
            }

            var mahasiswa = await _repositoriMahasiswa.GetWithDetail(id);
            if (mahasiswa == null)
            {
                _logger.LogError("Mahasiswa.Detail Mahasiswa dengan Id {id} tidak ada", id);

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Detail Mahasiswa",
                    Message = "Error mengambil data mahasiswa"
                });

                return RedirectToAction(nameof(Index));
            }

            return View(mahasiswa);
        }
    }
}
