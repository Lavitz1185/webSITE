using Microsoft.AspNetCore.Mvc;
using webSITE.DataAccess.Repositori.Interface;

namespace webSITE.Controllers
{
    public class FileController : Controller
    {
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileController(IRepositoriMahasiswa repositoriMahasiswa, 
            IRepositoriFoto repositoriFoto, 
            IWebHostEnvironment webHostEnvironment)
        {
            _repositoriMahasiswa = repositoriMahasiswa;
            _repositoriFoto = repositoriFoto;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> FotoProfil(string id)
        {
            var mahasiswa = await _repositoriMahasiswa.Get(id);

            if(mahasiswa == null)
                return NotFound();

            return File(mahasiswa.FotoProfil, "image/png");
        }

        public async Task<IActionResult> Foto(int id)
        {
            var foto = await _repositoriFoto.Get(id);

            if(foto is null) return NotFound();

            if(!System.IO.File.Exists(foto.Path)) return NotFound();

            return PhysicalFile(foto.Path, $"image/{Path.GetExtension(foto.Path)}");
        }
    }
}
