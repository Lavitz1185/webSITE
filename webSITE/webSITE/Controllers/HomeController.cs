using Microsoft.AspNetCore.Mvc;
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
            TempData[Utility.AlertTempDataKey] = "Pesan Error";
            return View();
        }

        public IActionResult Privacy()
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}