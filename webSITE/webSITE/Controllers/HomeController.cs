using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;
using webSITE.Models;
using webSITE.Utilities;

namespace webSITE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LaporError()
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

            return Redirect("/");
        }
    }
}