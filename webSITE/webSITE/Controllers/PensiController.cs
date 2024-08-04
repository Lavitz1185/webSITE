using Microsoft.AspNetCore.Mvc;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Domain.Abstractions;
using webSITE.Domain.Enum;
using webSITE.Domain.Exceptions.NimExceptions;
using webSITE.Domain.Exceptions.NoWaExceptions;
using webSITE.Domain.ValueObjects;
using webSITE.Models;
using webSITE.Models.PensiController;
using webSITE.Services.Contracts;

namespace webSITE.Controllers
{
    public class PensiController : Controller
    {
        private readonly IRepositoriLomba _repositoriLomba;
        private readonly IRepositoriPesertaLomba _repositoriPesertaLomba;
        private readonly IRepositoriTimLomba _repositoriTimLomba;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PensiController> _logger;
        private readonly INotificationService _notificationService;

        public PensiController(
            IRepositoriLomba repositoriLomba,
            IRepositoriPesertaLomba repositoriPesertaLomba,
            IRepositoriTimLomba repositoriTimLomba,
            IUnitOfWork unitOfWork,
            ILogger<PensiController> logger,
            INotificationService notificationService)
        {
            _repositoriLomba = repositoriLomba;
            _repositoriPesertaLomba = repositoriPesertaLomba;
            _repositoriTimLomba = repositoriTimLomba;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var daftarLomba = await _repositoriLomba.GetAll();

            return View(daftarLomba ?? new());
        }

        //Daftar
        public async Task<IActionResult> Daftar(int id)
        {
            var lomba = await _repositoriLomba.Get(id);

            if (lomba is null) return NotFound();

            ViewData["id"] = id;
            ViewData["PDFPath"] = lomba.PDFPath;

            return lomba.Jenis switch
            {
                JenisLomba.Solo => View("DaftarSolo", new TambahPesertaVM()),
                JenisLomba.Tim => View("DaftarTim", new TambahTimLombaVM()),
                JenisLomba.Pasangan =>
                    View(
                        "DaftarPasangan",
                        new TambahTimLombaVM { AnggotaTim = new() { new(), new() } }),
                _ => BadRequest()
            };
        }

        [HttpPost]
        public async Task<IActionResult> DaftarSolo(int id, TambahPesertaVM tambahPesertaVM)
        {
            ViewData["id"] = id;

            if (!ModelState.IsValid) return View(tambahPesertaVM);

            try
            {
                var lomba = await _repositoriLomba.GetWithDetail(id);

                if (lomba is null) return NotFound();

                var peserta = PesertaLomba.Create(
                    Nim.Create(tambahPesertaVM.Nim),
                    tambahPesertaVM.Nama,
                    tambahPesertaVM.JenisKelamin,
                    tambahPesertaVM.Angkatan,
                    NoWa.Create(tambahPesertaVM.NoWa),
                    DateTime.Now);

                _repositoriPesertaLomba.Add(peserta);
                lomba.TambahPeserta(peserta);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation(
                    "Peserta Solo NIM : {@nim} ditambahkan ke Lomba dengan ID : {@id} pada {@dateTime}",
                    tambahPesertaVM.Nim, id, DateTime.Now);

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Pendaftaran Sukse"
                });

                return View("DaftarSukses", lomba);
            }
            catch (InvalidNimException ex)
            {
                ModelState.AddModelError(nameof(TambahPesertaVM.Nim), ex.Message);
                return View(tambahPesertaVM);
            }
            catch (InvalidNoWaException ex)
            {
                ModelState.AddModelError(nameof(TambahPesertaVM.NoWa), ex.Message);
                return View(tambahPesertaVM);
            }
            catch (DomainException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tambahPesertaVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tambahPesertaVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DaftarPasangan(int id, TambahTimLombaVM tambahTimLombaVM)
        {
            ViewData["id"] = id;

            if (!ModelState.IsValid) return View(tambahTimLombaVM);

            try
            {
                var lomba = await _repositoriLomba.GetWithDetail(id);

                if (lomba is null) return NotFound();

                var tim = new TimLomba
                {
                    NamaTim = tambahTimLombaVM.NamaTim,
                    Angkatan = tambahTimLombaVM.Angkatan,
                    TanggalDaftar = DateTime.Now,
                    AnggotaTim = tambahTimLombaVM.AnggotaTim
                        .Select(a => PesertaLomba.Create(
                            Nim.Create(a.Nim),
                            a.Nama,
                            a.JenisKelamin,
                            tambahTimLombaVM.Angkatan,
                            NoWa.Create(tambahTimLombaVM.NoWa),
                            DateTime.Now)).ToList()
                };

                _repositoriTimLomba.Add(tim);
                lomba.TambahTim(tim);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation(
                    "Peserta Tim ID : {@timId} ditambahkan ke Lomba dengan ID : {@lombaId} pada {@dateTime}",
                    tim.Id, lomba.Id, DateTime.Now);

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Pendaftaran Sukse"
                });

                return View("DaftarSukses", lomba);
            }
            catch (DomainException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tambahTimLombaVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tambahTimLombaVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DaftarTim(int id, TambahTimLombaVM tambahTimVM)
        {
            ViewData["id"] = id;

            if (!ModelState.IsValid) return View(tambahTimVM);

            try
            {
                var lomba = await _repositoriLomba.GetWithDetail(id);

                if (lomba is null) return NotFound();

                var tim = new TimLomba
                {
                    NamaTim = tambahTimVM.NamaTim,
                    Angkatan = tambahTimVM.Angkatan,
                    TanggalDaftar = DateTime.Now,
                    AnggotaTim = tambahTimVM.AnggotaTim
                        .Select(a => PesertaLomba.Create(
                            Nim.Create(a.Nim),
                            a.Nama,
                            a.JenisKelamin,
                            tambahTimVM.Angkatan,
                            NoWa.Create(tambahTimVM.NoWa),
                            DateTime.Now)).ToList()
                };

                _repositoriTimLomba.Add(tim);
                lomba.TambahTim(tim);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation(
                    "Peserta Tim ID : {@timId} ditambahkan ke Lomba dengan ID : {@lombaId} pada {@dateTime}",
                    tim.Id, lomba.Id, DateTime.Now);

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Pendaftaran Sukse"
                });

                return View("DaftarSukses", lomba);
            }
            catch (DomainException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tambahTimVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tambahTimVM);
            }
        }

        [HttpPost]
        public IActionResult TambahAnggota(
            [Bind(nameof(TambahTimLombaVM.AnggotaTim))] TambahTimLombaVM tambahTimVM)
        {
            tambahTimVM.AnggotaTim.Add(new());

            ModelState.Clear();
            return PartialView("_TambahAnggotaTimVMPartial", tambahTimVM);
        }

        [HttpPost]
        public IActionResult HapusAnggota(
            [Bind(nameof(TambahTimLombaVM.AnggotaTim))] TambahTimLombaVM tambahTimVM, int indexAnggota)
        {
            if(tambahTimVM.AnggotaTim.Count > 0 && tambahTimVM.AnggotaTim.Count >= indexAnggota + 1)
            {
                tambahTimVM.AnggotaTim.RemoveAt(indexAnggota);
            }

            ModelState.Clear();
            return PartialView("_TambahAnggotaTimVMPartial", tambahTimVM);
        }
    }
}
