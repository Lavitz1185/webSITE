using Microsoft.AspNetCore.Mvc;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;

namespace webSITE.Controllers
{
    public class PensiController : Controller
    {
        private readonly IRepositoriLomba _repositoriLomba;
        private readonly IRepositoriPesertaLomba _repositoriPesertaLomba;
        private readonly IRepositoriTimLomba _repositoriTimLomba;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PensiController> _logger;

        public PensiController(
            IRepositoriLomba repositoriLomba,
            IRepositoriPesertaLomba repositoriPesertaLomba,
            IRepositoriTimLomba repositoriTimLomba,
            IUnitOfWork unitOfWork,
            ILogger<PensiController> logger)
        {
            _repositoriLomba = repositoriLomba;
            _repositoriPesertaLomba = repositoriPesertaLomba;
            _repositoriTimLomba = repositoriTimLomba;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var daftarLomba = await _repositoriLomba.GetAll();

            return View(daftarLomba ?? new());
        }
    }
}
