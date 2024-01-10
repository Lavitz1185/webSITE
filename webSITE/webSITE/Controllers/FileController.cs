using Microsoft.AspNetCore.Mvc;
using webSITE.Repositori.Implementasi;
using webSITE.Repositori.Interface;

namespace webSITE.Controllers
{
    public class FileController : Controller
    {
        private readonly IRepositoriMahasiswa repositoriMahasiswa;

        public FileController(IRepositoriMahasiswa repositoriMahasiswa)
        {
            this.repositoriMahasiswa = repositoriMahasiswa;
        }

        public async Task<FileResult> FotoProfil(string id)
        {
            var mahasiswa = await repositoriMahasiswa.Get(id);

            return File(mahasiswa.FotoProfil, "image/png");
        }
    }
}
