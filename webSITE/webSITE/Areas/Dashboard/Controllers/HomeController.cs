using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webSITE.Areas.Dashboard.Models.HomeController;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain.Enum;

namespace webSITE.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IRepositoriPengumuman _repositoriPengumuman;

        public HomeController(
            IRepositoriMahasiswa repositoriMahasiswa,
            IRepositoriKegiatan repositoriKegiatan,
            IRepositoriFoto repositoriFoto,
            IRepositoriPengumuman repositoriPengumuman)
        {
            _repositoriMahasiswa = repositoriMahasiswa;
            _repositoriKegiatan = repositoriKegiatan;
            _repositoriFoto = repositoriFoto;
            _repositoriPengumuman = repositoriPengumuman;
        }

        [Authorize(Roles = "Admin, ADMIN")]
        public async Task<IActionResult> Index()
        {
            var daftarMahasiswa = await _repositoriMahasiswa.GetAll();
            var daftarKegiatan = await _repositoriKegiatan.GetAll();
            var daftarFoto = await _repositoriFoto.GetAll();
            var daftarPengumuman = await _repositoriPengumuman.GetAll();

            daftarMahasiswa = daftarMahasiswa ?? new();
            daftarKegiatan = daftarKegiatan ?? new();
            daftarFoto = daftarFoto ?? new();
            daftarPengumuman = daftarPengumuman ?? new();

            return View(new IndexVM
            {
                TotalMahasiswa = daftarMahasiswa.Count,
                TotalMahasiswaPria = daftarMahasiswa.Where(m => m.JenisKelamin == JenisKelamin.LakiLaki).Count(),
                TotalMahasiswaWanita = daftarMahasiswa.Where(m => m.JenisKelamin == JenisKelamin.Perempuan).Count(),
                JumlahFoto = daftarFoto.Count,
                JumlahKegiatan = daftarKegiatan.Count,
                JumlahPengumuman = daftarPengumuman.Count
            });
        }
    }
}
