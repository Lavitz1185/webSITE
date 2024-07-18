using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.Models.FotoController;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Utilities;
using webSITE.Services.Contracts;
using webSITE.Models;
using webSITE.Configuration;
using Microsoft.Extensions.Options;

namespace webSITE.Controllers
{
    public class FotoController : Controller
    {
        private readonly PhotoFileSettingsOptions _photoFileSettings;

        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly INotificationService _notificationService;

        public FotoController(IRepositoriFoto repositoriFoto,
            IRepositoriKegiatan repositoriKegiatan,
            IMapper mapper,
            IRepositoriMahasiswa repositoriMahasiswa,
            IWebHostEnvironment webHostEnvironment,
            INotificationService notificationService,
            IOptions<PhotoFileSettingsOptions> options)
        {
            _photoFileSettings = options.Value;
            _repositoriFoto = repositoriFoto;
            _repositoriKegiatan = repositoriKegiatan;
            _mapper = mapper;
            _repositoriMahasiswa = repositoriMahasiswa;
            _webHostEnvironment = webHostEnvironment;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Album(int? idKegiatan, string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Foto", new { Area = "" });

            ViewData["ReturnUrl"] = returnUrl;

            if (idKegiatan is null)
            {
                var daftarFotoTanpaKegiatan = await _repositoriFoto.GetAllWithKegiatan();

                if (daftarFotoTanpaKegiatan is null || daftarFotoTanpaKegiatan.Count == 0)
                    return View(new AlbumVM
                    {
                        NamaKegiatan = "Lain - Lain"
                    });

                daftarFotoTanpaKegiatan = daftarFotoTanpaKegiatan
                    .Where(f => f.DaftarKegiatan.Count == 0)
                    .OrderBy(f => f.AddedAt)
                    .ToList();

                return View(new AlbumVM
                {
                    NamaKegiatan = "Lain - Lain",
                    Tanggal = daftarFotoTanpaKegiatan.First().AddedAt,
                    DaftarFoto = daftarFotoTanpaKegiatan.ToList()
                });
            }

            var kegiatan = await _repositoriKegiatan.GetWithDetail(idKegiatan.Value);

            if (kegiatan is null) return NotFound();

            var model = new AlbumVM
            {
                IdKegiatan = idKegiatan,
                NamaKegiatan = kegiatan.NamaKegiatan,
                Tanggal = kegiatan.Tanggal,
                DaftarFoto = kegiatan.DaftarFoto
                    .OrderBy(f => f.AddedAt)
                    .ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            var daftarFoto = (await _repositoriFoto.GetAllWithKegiatan()) ?? new();
            var daftarKegiatan = (await _repositoriKegiatan.GetAllWithDetail()) ?? new();

            List<AlbumVM> viewModel = new List<AlbumVM>();

            foreach (var kegiatan in daftarKegiatan)
            {
                if (kegiatan.DaftarFoto.Count > 0)
                {
                    var fotoThumbnail = kegiatan.DaftarFoto.OrderBy(f => f.AddedAt).First();
                    viewModel.Add(new AlbumVM
                    {
                        NamaKegiatan = kegiatan.NamaKegiatan,
                        IdKegiatan = kegiatan.Id,
                        IdThumbnail = fotoThumbnail.Id,
                        JumlahFoto = kegiatan.DaftarFoto.Count(),
                        Tanggal = fotoThumbnail.AddedAt,
                        DaftarFoto = kegiatan.DaftarFoto.ToList(),
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
                .Where(f => f.DaftarKegiatan.Count == 0)
                .OrderBy(f => f.AddedAt)
                .ToList();

            if (fotoTanpaKegiatan.Count > 0)
            {
                viewModel.Add(new AlbumVM
                {
                    NamaKegiatan = "Lain - Lain",
                    IdThumbnail = fotoTanpaKegiatan.First().Id,
                    JumlahFoto = fotoTanpaKegiatan.Count,
                    Tanggal = fotoTanpaKegiatan.First().AddedAt,
                    DaftarFoto = fotoTanpaKegiatan,
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
    }
}
