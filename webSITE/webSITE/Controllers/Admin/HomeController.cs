using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace webSITE.Controllers.Admin
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin, ADMIN")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
