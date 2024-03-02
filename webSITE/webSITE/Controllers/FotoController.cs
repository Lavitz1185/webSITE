﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.Models.FotoController;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Utilities;
using webSITE.Services.Contracts;
using webSITE.Models;

namespace webSITE.Controllers
{
    public class FotoController : Controller
    {
        private readonly string[] _permittedExtensions = { ".png", ".jpeg", ".jpg" };
        private readonly string _targetFilePath;
        private readonly long _fileSizeLimit;

        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly IRepositoriMahasiswaFoto _repositoriMahasiswaFoto;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly INotificationService _notificationService;

        public FotoController(IRepositoriFoto repositoriFoto,
            IRepositoriKegiatan repositoriKegiatan,
            IConfiguration config, IMapper mapper,
            IRepositoriMahasiswa repositoriMahasiswa,
            IWebHostEnvironment webHostEnvironment,
            IRepositoriMahasiswaFoto repositoriMahasiswaFoto,
            INotificationService notificationService)
        {
            _repositoriFoto = repositoriFoto;
            _repositoriKegiatan = repositoriKegiatan;
            _config = config;
            _mapper = mapper;
            _repositoriMahasiswa = repositoriMahasiswa;
            _webHostEnvironment = webHostEnvironment;
            _repositoriMahasiswaFoto = repositoriMahasiswaFoto;
            _notificationService = notificationService;

            _targetFilePath = _config.GetValue<string>("StoredFilesPath");
            _fileSizeLimit = _config.GetValue<long>("FileSizeLimit");
        }

        public async Task<IActionResult> DetailFoto(int? id, int? idKegiatan)
        {
            var daftarSemuaFoto = await _repositoriFoto.GetAllWithDetail();

            var daftarFotoAlbum = daftarSemuaFoto.Where(f => f.IdKegiatan == idKegiatan).ToList();

            if (daftarFotoAlbum == null || daftarFotoAlbum.Count == 0)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Info,
                    Title = "Detail Foto",
                    Message = $"Album tidak memiliki foto"
                });
                return RedirectToAction(nameof(Album), new {idKegiatan});
            }

            id = id ?? daftarFotoAlbum[0].Id;

            var fotoAktif = daftarFotoAlbum.Find(f => f.Id == id);

            ViewData["SelectedIndex"] = daftarFotoAlbum.IndexOf(fotoAktif);
            ViewData["IdKegiatan"] = idKegiatan;

            if (idKegiatan is not null)
                ViewData["NamaKegiatan"] = (await _repositoriKegiatan.Get(idKegiatan.Value)).NamaKegiatan;
            else
                ViewData["NamaKegiatan"] = "Lain - Lain";

            return View(daftarFotoAlbum);
        }

        public async Task<IActionResult> Album(int? idKegiatan, string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Foto", new { Area = "" });

            ViewData["ReturnUrl"] = returnUrl;

            if (idKegiatan == null)
            {
                var daftarFotoTanpaKegiatan = await _repositoriFoto.GetAll();

                daftarFotoTanpaKegiatan = daftarFotoTanpaKegiatan
                    .Where(f => f.IdKegiatan == null)
                    .OrderBy(f => f.Tanggal);

                if (daftarFotoTanpaKegiatan == null || daftarFotoTanpaKegiatan.Count() == 0)
                    return View(new AlbumVM
                    {
                        NamaKegiatan = "Lain - Lain"
                    });
                    
                return View(new AlbumVM
                {
                    NamaKegiatan = "Lain - Lain",
                    Tanggal = daftarFotoTanpaKegiatan.First().Tanggal,
                    DaftarFoto = daftarFotoTanpaKegiatan.ToList()
                });
            }

            var kegiatan = await _repositoriKegiatan.Get(idKegiatan ?? 0);

            if (kegiatan == null)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Album Foto",
                    Message = $"Kegiatan dengan Id = {idKegiatan} tidak ada"
                });
                return Redirect(returnUrl);
            }

            var daftarFoto = await _repositoriFoto.GetAllByKegiatan(kegiatan.Id);
            
            daftarFoto ??= new List<Foto>();

            var model = new AlbumVM
            {
                IdKegiatan = idKegiatan,
                NamaKegiatan = kegiatan.NamaKegiatan,
                Tanggal = kegiatan.Tanggal,
                DaftarFoto = daftarFoto
                    .OrderBy(f => f.Tanggal)
                    .ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            TempData[Utility.AlertTempDataKey] = "Halo Exception! Hanya Test";

            var daftarFoto = await _repositoriFoto.GetAll();
            var daftarKegiatan = await _repositoriKegiatan.GetAllWithDetail();

            List<AlbumVM> viewModel = new List<AlbumVM>();

            foreach (var kegiatan in daftarKegiatan)
            {
                if (kegiatan.DaftarFoto != null && kegiatan.DaftarFoto.Count > 0)
                {
                    var fotoThumbnail = kegiatan.DaftarFoto.OrderBy(f => f.Tanggal).First();
                    viewModel.Add(new AlbumVM
                    {
                        NamaKegiatan = kegiatan.NamaKegiatan,
                        IdKegiatan = kegiatan.Id,
                        IdThumbnail = fotoThumbnail.Id,
                        JumlahFoto = kegiatan.DaftarFoto.Count(),
                        Tanggal = fotoThumbnail.Tanggal,
                    });
                }
                else
                    viewModel.Add(new AlbumVM
                    {
                        NamaKegiatan = kegiatan.NamaKegiatan,
                        IdKegiatan = kegiatan.Id,
                        JumlahFoto = 0
                    });
            }

            var fotoTanpaKegiatan = daftarFoto
                .Where(f => f.IdKegiatan == null)
                .OrderBy(f => f.Tanggal)
                .ToList();

            if (fotoTanpaKegiatan != null && fotoTanpaKegiatan.Count > 0)
            {
                viewModel.Add(new AlbumVM
                {
                    NamaKegiatan = "Lain - Lain",
                    IdThumbnail = fotoTanpaKegiatan.First().Id,
                    JumlahFoto = fotoTanpaKegiatan.Count,
                    Tanggal = fotoTanpaKegiatan.First().Tanggal
                });
            }
            else
            {
                viewModel.Add(new AlbumVM
                {
                    NamaKegiatan = "Lain -Lain",
                    JumlahFoto = 0
                });
            }

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Tambah(int? idKegiatan)
        {
            var listMahasiswa = (await _repositoriMahasiswa.GetAll())
                .Select(m => new MahasiswaTambahFotoVM
                {
                    Id = m.Id,
                    NamaLengkap = m.NamaLengkap,
                    DalamFoto = false
                }).ToArray();

            return View(new TambahFotoVM
            {
                Tanggal = DateTime.Now,
                DaftarMahasiswaTambahFotoVM = listMahasiswa,
                IdKegiatan = idKegiatan
            });
        }

        [HttpPost]
        public async Task<IActionResult> Tambah(TambahFotoVM tambahFotoVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Perbaiki form!");
                return View(tambahFotoVM);
            }

            var formFileContent = await FileHelpers.ProcessFormFile<TambahFotoVM>(
                    tambahFotoVM.FotoFormFile, ModelState, _permittedExtensions, _fileSizeLimit);

            if (!ModelState.IsValid)
            {
                return View(tambahFotoVM);
            }

            var trustedFileNameForFileStorage = $"{Path.GetRandomFileName()}{Guid.NewGuid()}{Path.GetExtension(tambahFotoVM.FotoFormFile.FileName)}";
            var filePath = Path.Combine(
                _targetFilePath, trustedFileNameForFileStorage);

            Foto newFoto = _mapper.Map<Foto>(tambahFotoVM);
            newFoto.PhotoPath = filePath;

            var idMahasiswaDalamFoto = tambahFotoVM.DaftarMahasiswaTambahFotoVM
                .Where(x => x.DalamFoto == true)
                .Select(x => x.Id).ToList();

            newFoto = await _repositoriFoto.Create(newFoto);

            if (newFoto == null)
            {
                ModelState.AddModelError(string.Empty, "Error menambahkan foto");
                return View(tambahFotoVM);
            }

            using (var fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + filePath))
            {
                await fileStream.WriteAsync(formFileContent);
            }

            foreach (var id in idMahasiswaDalamFoto)
                await _repositoriMahasiswaFoto.Create(id, newFoto.Id);

            _notificationService.AddNotification(
                new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Tambah Foto Sukses",
                    Message = "Foto berhasil ditambahkan"
                });

            return RedirectToAction(nameof(Album), new {idKegiatan = tambahFotoVM.IdKegiatan});
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id, string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Action("Index");

            var result = await _repositoriFoto.Delete(id);

            if (result == null)
                _notificationService.AddNotification(
                    new ToastrNotification
                    {
                        Type = ToastrNotificationType.Error,
                        Title = "Hapus Foto Gagal",
                        Message = $"Foto dengan id {id} gagal dihapus"
                    });
            else
                _notificationService.AddNotification(
                    new ToastrNotification
                    {
                        Type = ToastrNotificationType.Success,
                        Title = "Hapus Foto Sukses",
                        Message = $"Foto dengan id {id} berhasil dihapus"
                    });


            return Redirect(returnUrl);
        }
    }
}
