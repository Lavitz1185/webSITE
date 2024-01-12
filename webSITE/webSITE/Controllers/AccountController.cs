﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webSITE.Models;
using webSITE.Repositori.Interface;
using webSITE.Utilities;

namespace webSITE.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<Mahasiswa> _userManager;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly IMapper _mapper;
        private readonly long _sizeLimit;
        private readonly string[] _permittedExtension = new string[] { ".png", ".jpg", ".jpeg" };

        public AccountController(
            UserManager<Mahasiswa> userManager,
            IRepositoriMahasiswa repositoriMahasiswa,
            IConfiguration config,
            IMapper mapper)
        {
            _userManager = userManager;
            _repositoriMahasiswa = repositoriMahasiswa;
            _mapper = mapper;

            _sizeLimit = config.GetValue<long>("FileSizeLimit");
        }

        public async Task<IActionResult> Index()
        {
            var mahasiswa = await _userManager.GetUserAsync(User);

            var accountIndexVM = _mapper.Map<AccountIndexVM>(mahasiswa);

            return View(accountIndexVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AccountIndexVM accountIndexVM)
        {
            var mahasiswa = _mapper.Map<Mahasiswa>(accountIndexVM);

            mahasiswa.Id = _userManager.GetUserId(User);

            mahasiswa = await _repositoriMahasiswa.Update(mahasiswa);

            if (mahasiswa == null)
            {
                ModelState.AddModelError(string.Empty, "Error Mengupdate Data");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> FotoProfil()
        {
            var accountFotoVM = new AccountFotoVM { Id = _userManager.GetUserId(User) };

            return View(accountFotoVM);
        }

        [HttpPost]
        public async Task<IActionResult> FotoProfil(AccountFotoVM accountFotoVM)
        {
            var mahasiswa = await _userManager.GetUserAsync(User);

            var photoData = await FileHelpers.ProcessFormFile<AccountFotoVM>(accountFotoVM.FotoFormFile
                , ModelState, _permittedExtension, _sizeLimit);

            accountFotoVM.Id = mahasiswa.Id;
            if(!ModelState.IsValid)
            {
                TempData["status"] = false;
                return View(accountFotoVM);
            }

            mahasiswa = await _repositoriMahasiswa.SetProfilePicture(mahasiswa.Id, photoData);

            if(mahasiswa == null)
            {
                ModelState.AddModelError(string.Empty, "Error Menambahkan data");
                TempData["status"] = false;
                return View(accountFotoVM);
            }

            TempData["status"] = true;
            return RedirectToAction("FotoProfil");
        }
    }
}