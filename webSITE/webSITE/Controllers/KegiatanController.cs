using Microsoft.AspNetCore.Mvc;
using webSITE.DataAccess.Repositori.Interface;

namespace webSITE.Controllers
{
    public class KegiatanController : Controller
    {
        private readonly IRepositoriKegiatan _repositoriKegiatan;

        public KegiatanController(IRepositoriKegiatan repositoriKegiatan)
        {
            _repositoriKegiatan = repositoriKegiatan;
        }

        public async Task<IActionResult> Index()
        {
            var listKegiatan = await _repositoriKegiatan.GetAllWithDetail();
            return View(listKegiatan ?? new());
        }
    }
}
