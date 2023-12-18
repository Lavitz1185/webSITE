using Microsoft.AspNetCore.Mvc;
using webSITE.Models;

namespace webSITE.Controllers
{
    public class MahasiswaController : Controller
    {
        public IActionResult Index()
        {
            var listMahasiswa = new List<Mahasiswa>()
            {
                new Mahasiswa()
                {
                    Nim = "2206080051",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    JenisKelamin = JenisKelamin.LakiLaki,
                    TahunMasuk = 2022,
                    TanggalLahir = new DateTime(2004, 02, 29),
                    PhotoPath = "/img/contoh.jpeg"
                },
                new Mahasiswa()
                {
                    Nim = "2206080011",
                    NamaLengkap = "Oswaldus Putra Fernando",
                    NamaPanggilan = "Fernand",
                    JenisKelamin = JenisKelamin.LakiLaki,
                    TahunMasuk = 2022,
                    TanggalLahir = new DateTime(2004, 02, 29),
                    PhotoPath = "/img/contoh.jpeg"
                },
                new Mahasiswa()
                {
                    Nim = "2206080021",
                    NamaLengkap = "Albertliano Tapatab",
                    NamaPanggilan = "Al",
                    JenisKelamin = JenisKelamin.LakiLaki,
                    TahunMasuk = 2022,
                    TanggalLahir = new DateTime(2004, 02, 29),
                    PhotoPath = "/img/contoh.jpeg"
                }
            };
            return View(listMahasiswa);
        }
    }
}
