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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Foto(int id)
        {
            var pengumuman = await _repositoriPengumuman.Get(id);

            if (pengumuman == null) return NotFound();

            return File(pengumuman.Foto, "image/jpeg");
        }
    }
}
