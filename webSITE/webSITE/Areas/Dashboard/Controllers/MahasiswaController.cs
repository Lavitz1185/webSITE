using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webSITE.Areas.Dashboard.Models;
using webSITE.Models;
using webSITE.Repositori.Interface;

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

        public MahasiswaController(IRepositoriMahasiswa repositoriMahasiswa,
            UserManager<Mahasiswa> userManagaer,
            IUserStore<Mahasiswa> userStore,
            IMapper mapper)
        {
            _repositoriMahasiswa = repositoriMahasiswa;
            _userManager = userManagaer;
            _userStore = userStore;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listMahasiswa = (await _repositoriMahasiswa.GetAll()).ToList();
            return View(listMahasiswa);
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
                return NotFound();

            await _repositoriMahasiswa.Delete(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(string id)
        {
            var mahasiswa = await _repositoriMahasiswa.Get(id);

            if(mahasiswa == null)
                return NotFound();

            return View(mahasiswa);
        }
    }
}
