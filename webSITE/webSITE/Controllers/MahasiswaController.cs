using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.Repositori.Interface;

namespace webSITE.Controllers
{
    public class MahasiswaController : Controller
    {
        private readonly IRepositoriMahasiswa repositoriMahasiswa;
        private readonly ILogger<MahasiswaController> logger;

        public MahasiswaController(
            IRepositoriMahasiswa repositoriMahasiswa, 
            ILogger<MahasiswaController> logger)
        {
            this.repositoriMahasiswa = repositoriMahasiswa;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var listMahasiwa = (await repositoriMahasiswa.GetAll()).Where(m => m.StatusAkun == StatusAkun.Aktif).ToList();
            return View(listMahasiwa);
        }

        public async Task<IActionResult> Detail(string id)
        {
            if (id == null)
            {
                logger.LogError("Mahasiswa.Detail Id null/tidak ada");
                return View();
            }

            var mahasiswa = await repositoriMahasiswa.GetWithDetail(id);
            if (mahasiswa == null)
            {
                logger.LogError("Mahasiswa.Detail Mahasiswa dengan Id {id} tidak ada", id);
                return View();
            }

            return View(mahasiswa);
        }
    }
}
