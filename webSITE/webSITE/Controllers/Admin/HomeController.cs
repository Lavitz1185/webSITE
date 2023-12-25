using Microsoft.AspNetCore.Mvc;

namespace webSITE.Controllers.Admin
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
