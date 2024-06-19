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
        private readonly PhotoFileSettings _photoFileSettings;

        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly IRepositoriMahasiswaFoto _repositoriMahasiswaFoto;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly INotificationService _notificationService;

        public FotoController(IRepositoriFoto repositoriFoto,
            IRepositoriKegiatan repositoriKegiatan,
            IMapper mapper,
            IRepositoriMahasiswa repositoriMahasiswa,
            IWebHostEnvironment webHostEnvironment,
            IRepositoriMahasiswaFoto repositoriMahasiswaFoto,
            INotificationService notificationService,
            IOptions<PhotoFileSettings> options)
        {
            _photoFileSettings = options.Value;
            _repositoriFoto = repositoriFoto;
            _repositoriKegiatan = repositoriKegiatan;
            _mapper = mapper;
            _repositoriMahasiswa = repositoriMahasiswa;
            _webHostEnvironment = webHostEnvironment;
            _repositoriMahasiswaFoto = repositoriMahasiswaFoto;
            _notificationService = notificationService;
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
    }
}
