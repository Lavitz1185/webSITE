using Microsoft.AspNetCore.Mvc;
using webSITE.Models;
using webSITE.Repositori.Implementasi;
using webSITE.Repositori.Interface;

namespace webSITE.Controllers
{
    public class FotoController : Controller
    {
        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IRepositoriKegiatan _repositoriKegiatan;

        public FotoController(IRepositoriFoto repositoriFoto, IRepositoriKegiatan repositoriKegiatan)
        {
            _repositoriFoto = repositoriFoto;
            this._repositoriKegiatan = repositoriKegiatan;
        }

        public async Task<IActionResult> DetailFoto(int id)
        {
            var foto = await _repositoriFoto.Get(id);

            if(foto == null)
                return NotFound();

            return View(foto);
        }

        public async Task<IActionResult> Detail(string? tanggal, int? idKegiatan)
        {
            if (tanggal == null && idKegiatan == null)
                return BadRequest();

            if(tanggal != null)
            {
                DateTime tanggalFoto = DateTime.Parse(tanggal);
                var listFoto = await _repositoriFoto.GetAllByTanggal(tanggalFoto);
                var model = new FotoViewModel
                {
                    OrderBy = "Tanggal",
                    Key = tanggal,
                    DaftarFoto = listFoto.ToList()
                };
                return View(model);
            }
            else
            {
                var kegiatan = await _repositoriKegiatan.Get(idKegiatan.Value);
                if(kegiatan == null)
                    return NotFound();

                var listFoto = await _repositoriFoto.GetAllByKegiatan(kegiatan.Id);
                var model = new FotoViewModel
                {
                    OrderBy = "Kegiatan",
                    Key = kegiatan.NamaKegiatan,
                    DaftarFoto = listFoto.ToList()
                };

                return View(model);
            }
        }

        public async Task<IActionResult> Index(string? groupBy)
        {
            if(groupBy == null)
                groupBy = "Tanggal";

            if (groupBy == "Tanggal")
            {
                var listFoto = await _repositoriFoto.GetAll();
                var model = (from f in listFoto
                             group f by f.Tanggal into grp
                             select new FotoViewModel
                             {
                                 OrderBy = "Tanggal",
                                 Key = grp.Key.ToShortDateString(),
                                 DaftarFoto = grp.Select(f => f).ToList()
                             }).ToList();

                return View(model);
            }
            else if (groupBy == "Kegiatan")
            {
                var listFoto = await _repositoriFoto.GetAll();
                var model = (from f in listFoto
                             group f by f.Kegiatan into grp
                             select new FotoViewModel
                             {
                                 OrderBy = "Kegiatan",
                                 Key = grp.Key.NamaKegiatan,
                                 DaftarFoto = grp.Select(f => f).ToList()
                             }).ToList();

                return View(model);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
