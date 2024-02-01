using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webSITE.Areas.Dashboard.Models.KegiatanController;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;

namespace webSITE.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, ADMIN")]
    public class KegiatanController : Controller
    {
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IRepositoriPesertaKegiatan _repositoriPesertaKegiatan;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IMapper _mapper;

        public KegiatanController(
            IRepositoriKegiatan repositoriKegiatan,
            IRepositoriPesertaKegiatan pesertaKegiatan,
            IRepositoriMahasiswa repositoriMahasiswa,
            IRepositoriFoto repositoriFoto,
            IMapper mapper)
        {
            _repositoriKegiatan = repositoriKegiatan;
            _repositoriPesertaKegiatan = pesertaKegiatan;
            _repositoriMahasiswa = repositoriMahasiswa;
            _repositoriFoto = repositoriFoto;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listKegiatan = (await _repositoriKegiatan.GetAll()).ToList();

            return View(listKegiatan);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var kegiatan = await _repositoriKegiatan.GetWithDetail(id);

            return View(kegiatan);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repositoriKegiatan.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> TambahKegiatan(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;

            ViewData["PageNumber"] = pageNumber;

            if (pageNumber == 1)
                ViewData["EnableNext"] = false;
            else
                ViewData["EnableNext"] = true;

            return View(new TambahKegiatanVM
            {
                Tanggal = DateTime.Now,
                JumlahHari = 1
            });
        }

        [HttpPost]
        public async Task<IActionResult> TambahKegiatan(TambahKegiatanVM tambahKegiatanVM)
        {
            //Validasi
            var kegiatanDB = await _repositoriKegiatan.GetKegiatanByNamaKegiatan(tambahKegiatanVM.NamaKegiatan);
            if (kegiatanDB != null)
            {
                ModelState.AddModelError("NamaKegiatan", "Kegiatan dengan nama yang sama sudah ada");
                ViewData["EnableNext"] = false;
                return View(tambahKegiatanVM);
            }

            var kegiatan = _mapper.Map<Kegiatan>(tambahKegiatanVM);
            kegiatan.Id = 0;
            kegiatan = await _repositoriKegiatan.Create(kegiatan);
            if(kegiatan == null)
            {
                ModelState.AddModelError(string.Empty, "Error menambahkan data, silahkan hubungi admin");
                ViewData["EnableNext"] = false;
                return View(tambahKegiatanVM);
            }

            ViewData["IdKegiatan"] = kegiatan.Id;
            ViewData["PageNumber"] = 2;
            ViewData["EnableNext"] = true;
            return View();
        }
    }
}
