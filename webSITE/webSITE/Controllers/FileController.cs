using Microsoft.AspNetCore.Mvc;
using webSITE.Repositori.Implementasi;
using webSITE.Repositori.Interface;

namespace webSITE.Controllers
{
    public class FileController : Controller
    {
        private readonly IRepositoriMahasiswa repositoriMahasiswa;
        private readonly IRepositoriFoto repositoriFoto;

        public FileController(IRepositoriMahasiswa repositoriMahasiswa, IRepositoriFoto repositoriFoto)
        {
            this.repositoriMahasiswa = repositoriMahasiswa;
            this.repositoriFoto = repositoriFoto;
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

            return PhysicalFile(foto.PhotoPath, "image/jpeg");
        }
    }
}
