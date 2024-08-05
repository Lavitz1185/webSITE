using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using webSITE.Areas.Dashboard.Models.PensiController;
using webSITE.Configuration;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Domain.Abstractions;
using webSITE.Domain.Exceptions.LombaExceptions;
using webSITE.Models;
using webSITE.Services.Contracts;
using webSITE.Utilities;

namespace webSITE.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class PensiController : Controller
    {
        private readonly IRepositoriLomba _repositoriLomba;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToastrNotificationService _notificationService;
        private readonly ILogger<PensiController> _logger;
        private readonly IRepositoriPesertaLomba _repositoriPesertaLomba;
        private readonly IRepositoriTimLomba _repositoriTimLomba;
        private readonly IRepositoriFoto _repositoriFoto;
        private readonly PDFFileSettingsOptions _pDFFileSettingsOptions;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PensiController(
            IRepositoriLomba repositoriLomba,
            IUnitOfWork unitOfWork,
            IToastrNotificationService notificationService,
            ILogger<PensiController> logger,
            IRepositoriPesertaLomba repositoriPesertaLomba,
            IRepositoriTimLomba repositoriTimLomba,
            IRepositoriFoto repositoriFoto,
            IOptions<PDFFileSettingsOptions> pDFFileSettingsOptions,
            IWebHostEnvironment webHostEnvironment)
        {
            _repositoriLomba = repositoriLomba;
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
            _logger = logger;
            _repositoriPesertaLomba = repositoriPesertaLomba;
            _repositoriTimLomba = repositoriTimLomba;
            _repositoriFoto = repositoriFoto;
            _pDFFileSettingsOptions = pDFFileSettingsOptions.Value;
            _webHostEnvironment = webHostEnvironment;
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

            var pathPDF = await SavePDFAsync<TambahVM>(tambahVM.FilePDF);

            if(pathPDF is null) return View(tambahVM);

            //Simpan ke database
            try
            {
                var lomba = Lomba.Create(
                    tambahVM.Nama,
                    tambahVM.Jenis,
                    tambahVM.MaksKuotaPerAngkatan,
                    new Uri(tambahVM.LinkGrupWa),
                    pathPDF,
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

            if (!System.IO.File.Exists(Path.Combine(_webHostEnvironment.WebRootPath + lomba.PDFPath))
                && editVM.FilePDF is null)
            {
                ModelState.AddModelError(nameof(EditVM.FilePDF), "File PDF lama tidak ada jadi harus diisi");
                return View(editVM);
            }

            try
            {
                lomba.Nama = editVM.Nama;
                lomba.LinkGrupWa = new Uri(editVM.LinkGrupWa);
                lomba.FotoLomba = foto;

                if(editVM.FilePDF is not null)
                {
                    var pdfPath = await SavePDFAsync<EditVM>(editVM.FilePDF);

                    if (pdfPath is null) return View(editVM);

                    lomba.PDFPath = pdfPath;
                }

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

        [HttpPost]
        public async Task<IActionResult> HapusPeserta(int id, int idPeserta)
        {
            //Validasi
            var lomba = await _repositoriLomba.GetWithDetail(id);

            if (lomba is null) return NotFound();

            var peserta = lomba.DaftarPeserta.FirstOrDefault(x => x.Id == idPeserta);

            if(peserta is null) return NotFound();

            //Simpan perubahan ke database
            try
            {
                lomba.HapusPeserta(peserta);

                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Hapus Peserta Sukses",
                });
            }
            catch(DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Peserta Gagal",
                    Message = ex.Message,
                });
            }
            catch(Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Peserta Gagal",
                });
                _logger.LogError(ex, "Unhandled Exception Message : {@message}, DateTime : {@dateTime}",
                    ex.Message, DateTime.Now);
            }
                
            return RedirectToAction(nameof(Detail), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> HapusTim(int id, int idTim)
        {
            //Validasi
            var lomba = await _repositoriLomba.GetWithDetail(id);

            if (lomba is null) return NotFound();

            var tim = lomba.DaftarTim.FirstOrDefault(x => x.Id == idTim);

            if (tim is null) return NotFound();

            //Simpan perubahan ke database
            try
            {
                lomba.HapusTim(tim);

                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Hapus Tim Sukses",
                });
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Tim Gagal",
                    Message = ex.Message,
                });
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Tim Gagal",
                });
                _logger.LogError(ex, "Unhandled Exception Message : {@message}, DateTime : {@dateTime}",
                    ex.Message, DateTime.Now);
            }

            return RedirectToAction(nameof(Detail), new { id });
        }

        private async Task<string?> SavePDFAsync<TModel>(IFormFile formFile)
        {
            try
            {
                var fileFormContent = await FileHelpers.ProcessFormFile<TModel>(formFile, ModelState,
                    new string[] { ".pdf" }, _pDFFileSettingsOptions.SizeLimit);

                if(!ModelState.IsValid)
                {
                    return null;
                }

                var fileName = $"{Path.GetRandomFileName()}{Path.GetExtension(formFile.FileName)}";
                var filePath = $"{_pDFFileSettingsOptions.FolderPath}/{fileName}";

                using (FileStream fs = System.IO.File.Create($"{_webHostEnvironment.WebRootPath}/{filePath}"))
                {
                    await fs.WriteAsync(fileFormContent);
                }

                return filePath;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error menyimpan file PDF {@namaFile}. Timestamp : {@timeStamp}",
                    formFile.FileName, DateTime.Now);

                ModelState.AddModelError(formFile.FileName, "Error menyimpan file PDF");

                return null;
            }
        }
    }
}
