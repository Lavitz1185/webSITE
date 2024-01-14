using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.Repositori.Interface;

namespace webSITE.Controllers
{
    public class KegiatanController : Controller
    {
        private readonly IRepositoriKegiatan _repositoriKegiatan;

        public KegiatanController(IRepositoriKegiatan repositoriKegiatan)
        {
            _repositoriKegiatan = repositoriKegiatan;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var listKegiatan = (await _repositoriKegiatan.GetAll()).ToList();
            return View(listKegiatan);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest("Parameter id harus diisi");

            var kegiatan = await _repositoriKegiatan.GetWithDetail(id.Value);

            if (kegiatan == null)
                return NotFound($"Kegiatan dengan id {id} tidak ditemukan");

            return View(kegiatan);
        }
    }
}
