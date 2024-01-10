using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webSITE.Models;
using webSITE.Repositori.Implementasi;
using webSITE.Repositori.Interface;
using webSITE.Utilities;

namespace webSITE.Controllers
{
    public class FotoController : Controller
    {
        private readonly string[] _permittedExtensions = { ".png", ".jpeg", ".jpg" };
        private readonly string _targetFilePath;
        private readonly long _fileSizeLimit;

        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public FotoController(IRepositoriFoto repositoriFoto, IRepositoriKegiatan repositoriKegiatan, IConfiguration config, IMapper mapper)
        {
            _repositoriFoto = repositoriFoto;
            _repositoriKegiatan = repositoriKegiatan;
            _config = config;

            _targetFilePath = _config.GetValue<string>("StoredFilesPath");
            _fileSizeLimit = _config.GetValue<long>("FileSizeLimit");
            _mapper = mapper;
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
                var listFoto = (await _repositoriFoto.GetAll()).Where(f => f.Kegiatan != null).ToList();
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Tambah()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Tambah(TambahFotoVM tambahFotoVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Perbaiki form!");
                return View();
            }

            var formFileContent =
                await FileHelpers.ProcessFormFile<TambahFotoVM>(
                    tambahFotoVM.FotoFormFile, ModelState, _permittedExtensions,
                    _fileSizeLimit);

            if (!ModelState.IsValid)
            {
                return View();
            }

            var trustedFileNameForFileStorage = $"{Path.GetRandomFileName()}{Guid.NewGuid()}{Path.GetExtension(tambahFotoVM.FotoFormFile.FileName)}";
            var filePath = Path.Combine(
                _targetFilePath, trustedFileNameForFileStorage);

            using (var fileStream = System.IO.File.Create(filePath))
            {
                await fileStream.WriteAsync(formFileContent);
            }

            Foto newFoto = _mapper.Map<Foto>(tambahFotoVM);
            newFoto.PhotoPath = filePath;

            newFoto = await _repositoriFoto.Create(newFoto);

            if(newFoto == null)
            {
                ModelState.AddModelError(string.Empty, "Error menambahkan foto");
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
