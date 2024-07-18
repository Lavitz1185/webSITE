using Microsoft.AspNetCore.Mvc;
using webSITE.DataAccess.Repositori.Interface;

namespace webSITE.Controllers
{
    public class PengumumanController : Controller
    {
        private readonly IRepositoriPengumuman _repositoriPengumuman;

        public PengumumanController(IRepositoriPengumuman repositoriPengumuman)
        {
            _repositoriPengumuman = repositoriPengumuman;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repositoriPengumuman.GetAll());
        }

        public IActionResult Pensi()
        {
            return View();
        }
    }
}
