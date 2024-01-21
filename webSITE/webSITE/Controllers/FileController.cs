using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.DataAccess.Repositori.Interface;

namespace webSITE.Controllers
{
    public class FileController : Controller
    {
        private readonly IRepositoriMahasiswa repositoriMahasiswa;
        private readonly IRepositoriFoto repositoriFoto;
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileController(IRepositoriMahasiswa repositoriMahasiswa, 
            IRepositoriFoto repositoriFoto, 
            IWebHostEnvironment webHostEnvironment)
        {
            this.repositoriMahasiswa = repositoriMahasiswa;
            this.repositoriFoto = repositoriFoto;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> FotoProfil(string id)
        {
            var mahasiswa = await repositoriMahasiswa.Get(id);

            if(mahasiswa == null)
                return NotFound();

            return File(mahasiswa.FotoProfil, "image/png");
        }

        public async Task<IActionResult> Foto(int id)
        {
            var foto = await repositoriFoto.Get(id);

            if(foto == null) return NotFound();

            return PhysicalFile(webHostEnvironment.WebRootPath + foto.PhotoPath, "image/jpeg");
        }
    }
}
