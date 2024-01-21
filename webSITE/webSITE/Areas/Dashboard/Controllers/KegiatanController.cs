using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webSITE.Repositori.Interface;

namespace webSITE.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, ADMIN")]
    public class KegiatanController : Controller
    {
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IRepositoriPesertaKegiatan _pesertaKegiatan;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;

        public KegiatanController(
            IRepositoriKegiatan repositoriKegiatan, 
            IRepositoriPesertaKegiatan pesertaKegiatan, 
            IRepositoriMahasiswa repositoriMahasiswa)
        {
            _repositoriKegiatan = repositoriKegiatan;
            _pesertaKegiatan = pesertaKegiatan;
            _repositoriMahasiswa = repositoriMahasiswa;
        }

        public async Task<IActionResult> Index()
        {
            var listKegiatan = (await _repositoriKegiatan.GetAll()).ToList();

            return View(listKegiatan);
        }
    }
}
