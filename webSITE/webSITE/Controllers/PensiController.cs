using Microsoft.AspNetCore.Mvc;
using webSITE.DataAccess.Repositori.Interface;

namespace webSITE.Controllers
{
    public class PensiController : Controller
    {
        private readonly IRepositoriLomba _repositoriLomba;

        public PensiController(IRepositoriLomba repositoriLomba)
        {
            _repositoriLomba = repositoriLomba;
        }

        public async Task<IActionResult> Index()
        {
            var daftarLomba = await _repositoriLomba.GetAll();

            return View(daftarLomba ?? new());
        }
    }
}
