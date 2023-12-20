using Microsoft.AspNetCore.Mvc;
using webSITE.Models;
using webSITE.Repositori.Interface;

namespace webSITE.Controllers
{
    public class MahasiswaController : Controller
    {
        private readonly IRepositoriMahasiswa repositoriMahasiswa;

        public MahasiswaController(IRepositoriMahasiswa repositoriMahasiswa)
        {
            this.repositoriMahasiswa = repositoriMahasiswa;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var listMahasiwa = await repositoriMahasiswa.GetAll();
            return View(listMahasiwa);
        }
    }
}
