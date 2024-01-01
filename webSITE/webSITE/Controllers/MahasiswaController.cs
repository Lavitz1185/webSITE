using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public async Task<IActionResult> DetailAsync(string? nim)
        {
            if(nim == null)
                return NotFound();

            var mahasiswa = await repositoriMahasiswa.GetByNim(nim);
            if(mahasiswa == null)
                return NotFound();

            return View(mahasiswa);
        }
    }
}
