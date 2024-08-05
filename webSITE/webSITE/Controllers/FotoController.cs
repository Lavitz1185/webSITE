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
        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IRepositoriKegiatan _repositoriKegiatan;

        public FotoController(IRepositoriFoto repositoriFoto,
            IRepositoriKegiatan repositoriKegiatan)
        {
            _repositoriFoto = repositoriFoto;
            _repositoriKegiatan = repositoriKegiatan;
        }
        public async Task<IActionResult> Album(int idKegiatan, string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Foto", new { Area = "" });

            ViewData["ReturnUrl"] = returnUrl;

            var kegiatan = await _repositoriKegiatan.GetWithDetail(idKegiatan);

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

            if (kegiatan.FotoThumbnail is not null)
                model.DaftarFoto.Add(kegiatan.FotoThumbnail);

            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            var daftarKegiatan = (await _repositoriKegiatan.GetAllWithDetail()) ?? new();

            List<AlbumVM> viewModel = new List<AlbumVM>();

            foreach (var kegiatan in daftarKegiatan)
            {
                var album = new AlbumVM
                {
                    NamaKegiatan = kegiatan.NamaKegiatan,
                    IdKegiatan = kegiatan.Id,
                    IdThumbnail = kegiatan.FotoThumbnail?.Id,
                    Tanggal = kegiatan.Tanggal,
                    DaftarFoto = kegiatan.DaftarFoto.ToList(),
                };

                if (kegiatan.FotoThumbnail is not null)
                    album.DaftarFoto.Add(kegiatan.FotoThumbnail);

                album.JumlahFoto = album.DaftarFoto.Count;

                viewModel.Add(album);
            }

            return View(viewModel);
        }
    }
}
