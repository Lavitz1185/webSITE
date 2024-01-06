using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webSITE.Repositori.Interface;

namespace webSITE.Controllers.Admin
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, ADMIN")]
    public class MahasiswaController : Controller
    {
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;

        public MahasiswaController(IRepositoriMahasiswa repositoriMahasiswa)
        {
            _repositoriMahasiswa = repositoriMahasiswa;
        }

        public async Task<IActionResult> Index()
        {
            var listMahasiswa = (await _repositoriMahasiswa.GetAll()).ToList();
            return View(listMahasiswa);
        }
    }
}
