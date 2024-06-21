using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Services.Contracts;
using webSITE.Models;
using webSITE.Utilities;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<IActionResult> Index(int? pageIndex, string? searchString)
        {
            IEnumerable<Mahasiswa> listMahasiwa = (await _repositoriMahasiswa.GetAll())
                .Where(m => m.StatusAkun == StatusAkun.Aktif)
                .OrderBy(m => long.Parse(m.Nim));

            if (searchString != null && !searchString.IsNullOrEmpty()) 
            { 
                listMahasiwa = listMahasiwa
                    .Where(m => m.NamaLengkap.ToLower().Contains(searchString.ToLower()) || m.NamaPanggilan.ToLower().Contains(searchString.ToLower()) || m.Nim.ToLower().Contains(searchString.ToLower()));
            }

            ViewData["searchString"] = searchString;

            var items = PaginatedList<Mahasiswa>.CreateAsync(listMahasiwa, pageIndex ?? 1, 12);

            return View(items);
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
