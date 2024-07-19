﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Areas.Dashboard.Models.MahasiswaController;
using webSITE.DataAccess.Data;
using webSITE.Domain.Exceptions.MahasiswaExceptions;

namespace webSITE.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, ADMIN")]
    public class MahasiswaController : Controller 
    {
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly UserManager<Mahasiswa> _userManager;
        private readonly IUserStore<Mahasiswa> _userStore;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MahasiswaController> _logger;

        public MahasiswaController(IRepositoriMahasiswa repositoriMahasiswa,
            UserManager<Mahasiswa> userManagaer,
            IUserStore<Mahasiswa> userStore,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger<MahasiswaController> logger)
        {
            _repositoriMahasiswa = repositoriMahasiswa;
            _userManager = userManagaer;
            _userStore = userStore;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var listMahasiswa = await _repositoriMahasiswa.GetAll();
            return View(listMahasiswa ?? new());
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (_userManager.GetUserId(User) == id)
                return NotFound();

            var mahasiswa = await _repositoriMahasiswa.Get(id);

            if(mahasiswa == null)
                return NotFound("Mahasiswa tidak ditemukan");

            var editMahasiswaVM = _mapper.Map<EditMahasiswaVM>(mahasiswa);
            
            editMahasiswaVM.Admin = await _userManager.IsInRoleAsync(mahasiswa, "Admin");

            return View(editMahasiswaVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMahasiswaVM mahasiswaVM)
        {
            var mahasiswa = await _userStore.FindByIdAsync(mahasiswaVM.Id, CancellationToken.None);

            mahasiswa.StatusAkun = mahasiswaVM.StatusAkun;

            var result = await _userStore.UpdateAsync(mahasiswa, CancellationToken.None);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return RedirectToAction("Edit");
            }

            if(mahasiswaVM.Admin)
            {
                result = await _userManager.AddToRoleAsync(mahasiswa, "Admin");

                if(!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);

                    return RedirectToAction("Edit");
                }
            }
            else
            {
                result = await _userManager.RemoveFromRoleAsync(mahasiswa, "Admin");

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);

                    return RedirectToAction("Edit");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (_userManager.GetUserId(User) == id)
                return BadRequest();

            try
            {
                await _repositoriMahasiswa.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (MahasiswaNotFoundException ex)
            {
                _logger.LogError("Delete. Exception : {0}", ex.ToString());
                return NotFound();
            }
            catch(Exception ex)
            {
                _logger.LogError("Delete. Exception : {0}", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(string id)
        {
            var mahasiswa = await _repositoriMahasiswa.GetWithDetail(id);

            if(mahasiswa == null)
                return NotFound();

            return View(mahasiswa);
        }
    }
}
