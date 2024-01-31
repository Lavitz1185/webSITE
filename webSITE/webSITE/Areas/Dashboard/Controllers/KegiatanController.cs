﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webSITE.Areas.Dashboard.Models.KegiatanController;
using webSITE.DataAccess.Repositori.Interface;

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

        public KegiatanController(
            IRepositoriKegiatan repositoriKegiatan,
            IRepositoriPesertaKegiatan pesertaKegiatan,
            IRepositoriMahasiswa repositoriMahasiswa,
            IRepositoriFoto repositoriFoto)
        {
            _repositoriKegiatan = repositoriKegiatan;
            _repositoriPesertaKegiatan = pesertaKegiatan;
            _repositoriMahasiswa = repositoriMahasiswa;
            _repositoriFoto = repositoriFoto;
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

        public async Task<IActionResult> TambahKegiatan(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;

            ViewData["PageNumber"] = pageNumber;

            if (pageNumber == 1)
                ViewData["EnableNext"] = false;
            else
                ViewData["EnableNext"] = true;

            return View(new TambahKegiatanVM
            {
                TanggalMulai = DateTime.Now,
                TanggalBerakhir = DateTime.Now
            });
        }

        [HttpPost]
        public async Task<IActionResult> TambahKegiatan(TambahKegiatanVM tambahKegiatanVM)
        {
            return RedirectToAction(nameof(TambahKegiatan), new { pageNumber = 2 });
        }
    }
}
