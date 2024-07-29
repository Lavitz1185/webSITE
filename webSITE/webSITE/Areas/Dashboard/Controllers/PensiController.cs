using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webSITE.Areas.Dashboard.Models.PensiController;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Domain.Abstractions;
using webSITE.Domain.Exceptions.LombaExceptions;
using webSITE.Models;
using webSITE.Services.Contracts;

namespace webSITE.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class PensiController : Controller
    {
        private readonly IRepositoriLomba _repositoriLomba;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;
        private readonly ILogger<PensiController> _logger;
        private readonly IRepositoriPesertaLomba _repositoriPesertaLomba;
        private readonly IRepositoriTimLomba _repositoriTimLomba;
        private readonly IRepositoriFoto _repositoriFoto;

        public PensiController(
            IRepositoriLomba repositoriLomba,
            IUnitOfWork unitOfWork,
            INotificationService notificationService,
            ILogger<PensiController> logger,
            IRepositoriPesertaLomba repositoriPesertaLomba,
            IRepositoriTimLomba repositoriTimLomba,
            IRepositoriFoto repositoriFoto)
        {
            _repositoriLomba = repositoriLomba;
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
            _logger = logger;
            _repositoriPesertaLomba = repositoriPesertaLomba;
            _repositoriTimLomba = repositoriTimLomba;
            _repositoriFoto = repositoriFoto;
        }

        public async Task<IActionResult> Index()
        {
            var daftarLomba = await _repositoriLomba.GetAllWithDetail();

            daftarLomba = daftarLomba ?? new();

            return View(daftarLomba.OrderBy(l => l.Jenis).ToList());
        }

        //Detail Lomba
        public async Task<IActionResult> Detail(int id)
        {
            var lomba = await _repositoriLomba.GetWithDetail(id);

            if (lomba is null) return NotFound();

            return View(lomba);
        }

        //Tambah Lomba
        public IActionResult Tambah()
        {
            return View(new TambahVM());
        }

        [HttpPost]
        public async Task<IActionResult> Tambah(TambahVM tambahVM)
        {
            //Validasi
            if (!ModelState.IsValid) return View(tambahVM);

            var foto = await _repositoriFoto.Get(tambahVM.FotoId);

            if (foto is null)
            {
                ModelState.AddModelError(nameof(TambahVM.FotoId), "Foto tidak ditemukan");
                return View(tambahVM);
            }

            //Simpan ke database
            try
            {
                var lomba = Lomba.Create(
                    tambahVM.Nama,
                    tambahVM.Jenis,
                    tambahVM.Keterangan,
                    tambahVM.MaksKuotaPerAngkatan,
                    new Uri(tambahVM.LinkGrupWa),
                    tambahVM.MinAnggotaPerTim,
                    tambahVM.MaksAnggotaPerTim,
                    tambahVM.PasanganBedaJenisKelamin);

                lomba.FotoLomba = foto;

                _repositoriLomba.Add(lomba);

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Lomba baru ditambahkan pada {@dateTime}", DateTime.Now);
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Lomba Sukses Ditambahkan!"
                });
                return RedirectToAction(nameof(Index));
            }
            catch (DomainException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tambahVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tambahVM);
            }
        }

        //Edit Lomba
        public async Task<IActionResult> Edit(int id)
        {
            var lomba = await _repositoriLomba.Get(id);

            if (lomba is null) return NotFound();

            return View(new EditVM
            {
                Id = lomba.Id,
                Nama = lomba.Nama,
                Keterangan = lomba.Keterangan,
                LinkGrupWa = lomba.LinkGrupWa.ToString(),
                FotoId = lomba.FotoLomba?.Id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditVM editVM)
        {
            //Validasi
            if (!ModelState.IsValid) return View(editVM);

            var foto = await _repositoriFoto.Get(editVM.FotoId!.Value);

            if (foto is null)
            {
                ModelState.AddModelError(nameof(EditVM.FotoId), "Foto tidak ditemukan");
                return View(editVM);
            }

            var lomba = await _repositoriLomba.Get(editVM.Id);

            if (lomba is null)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Edit Gagal Gagal",
                    Message = "Lomba yang akan diedit tidak ditemukan"
                });
                return RedirectToAction(nameof(Index));
            }

            try
            {
                lomba.Nama = editVM.Nama;
                lomba.Keterangan = editVM.Keterangan;
                lomba.LinkGrupWa = new Uri(editVM.LinkGrupWa);
                lomba.FotoLomba = foto;

                _repositoriLomba.Update(lomba);

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Lomba Id : {@id} diubah pada {@dateTime}", editVM.Id, DateTime.Now);

                return RedirectToAction(nameof(Index));
            }
            catch (DomainException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(editVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(editVM);
            }
        }

        //Hapus Lomba
        [HttpPost]
        public async Task<IActionResult> Hapus(int id)
        {
            //Validasi
            try
            {
                await _repositoriLomba.Delete(id);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Hapus lomba dengan Id : {@id} pada {@dateTime}", id, DateTime.Now);
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Hapus Lomba Sukses"
                });
                return RedirectToAction(nameof(Index));
            }
            catch (LombaNotFoundException ex)
            {
                _logger.LogError(ex, "Error hapus lomba dengan ID : {@id} pada {@dateTime}. Message {@message}",
                    id, DateTime.Now, ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error hapus lomba dengan ID : {@id} pada {@dateTime}. Message {@message}",
                    id, DateTime.Now, ex.Message);
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Gagal!"
                });
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
