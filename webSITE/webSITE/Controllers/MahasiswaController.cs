using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Services.Contracts;
using webSITE.Models;
using webSITE.Utilities;
using Microsoft.IdentityModel.Tokens;
using webSITE.Domain.Enum;

namespace webSITE.Controllers
{
    public class MahasiswaController : Controller
    {
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly ILogger<MahasiswaController> _logger;
        private readonly IToastrNotificationService _notificationService;

        public MahasiswaController(
            IRepositoriMahasiswa repositoriMahasiswa,
            ILogger<MahasiswaController> logger,
            IToastrNotificationService notificationService)
        {
            _repositoriMahasiswa = repositoriMahasiswa;
            _logger = logger;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index(int? pageIndex, string? searchString)
        {
            var listMahasiwa = await _repositoriMahasiswa.GetAll();

            listMahasiwa = listMahasiwa?.OrderBy(x => x.Nim).ToList();

            if (searchString != null && !searchString.IsNullOrEmpty()) 
            {
                var searchWords = searchString.Split(" ", 
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                listMahasiwa = listMahasiwa?
                    .Where(m => searchWords.Any(s => m.NamaLengkap.ToLower().Contains(s.ToLower()) ||
                                                     m.NamaPanggilan.ToLower().Contains(s.ToLower())))
                    .ToList();
            }

            ViewData["searchString"] = searchString;

            var items = PaginatedList<Mahasiswa>.CreateAsync(listMahasiwa ?? new(), pageIndex ?? 1, 12);

            return View(items);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var mahasiswa = await _repositoriMahasiswa.GetWithDetail(id);

            if (mahasiswa is null) return NotFound();

            return View(mahasiswa);
        }
    }
}
