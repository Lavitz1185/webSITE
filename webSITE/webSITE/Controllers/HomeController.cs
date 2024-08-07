using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Models;
using webSITE.Models.Home;
using webSITE.Utilities;

namespace webSITE.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger,
            IRepositoriKegiatan repositoriKegiatan,
            IRepositoriMahasiswa repositoriMahasiswa)
        {
            _logger = logger;
            _repositoriKegiatan = repositoriKegiatan;
            _repositoriMahasiswa = repositoriMahasiswa;
        }

        public async Task<IActionResult> Index()
        {
            var daftarKegiatan = await _repositoriKegiatan.GetAllWithDetail();

            daftarKegiatan = daftarKegiatan?
                .OrderByDescending(k => k.Tanggal.Date)
                .Take(3).ToList();

            var daftarMahasiswa = await _repositoriMahasiswa.GetRandom(7);

            return View(new IndexVM
            {
                DaftarKegiatan = daftarKegiatan ?? new(),
                DaftarMahasiswa = daftarMahasiswa ?? new(),
            });
        }

        public IActionResult LaporError()
        {
            return View();
        }

        public IActionResult ProblemBadRequest()
        {
            return BadRequest();
        }

        public IActionResult InternalServerError()
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        public IActionResult StatusCode404()
        {
            return View();
        }

        public IActionResult StatusCode400()
        {
            return View();
        }

        public IActionResult StatusCode500()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var path = HttpContext.Request.Path;

            if (exceptionHandlerPathFeature?.Error is SqlException)
                TempData[Utility.AlertTempDataKey] = "Database error";
            else if (exceptionHandlerPathFeature?.Error is Exception)
                TempData[Utility.AlertTempDataKey] = "Telah terjadi error pada server";

            _logger.LogError(exceptionHandlerPathFeature?.Error,
                "Unhandled Exception. Message : {@message}. At {@dateTimes}",
                exceptionHandlerPathFeature?.Error?.Message, DateTime.Now);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}