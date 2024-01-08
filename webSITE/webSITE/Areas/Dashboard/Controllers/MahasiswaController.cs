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

        public MahasiswaController(IRepositoriMahasiswa repositoriMahasiswa,
            UserManager<Mahasiswa> userManagaer,
            IUserStore<Mahasiswa> userStore)
        {
            _repositoriMahasiswa = repositoriMahasiswa;
            _userManager = userManagaer;
            _userStore = userStore;
        }

        public async Task<IActionResult> Index()
        {
            var listMahasiswa = (await _repositoriMahasiswa.GetAll()).ToList();
            return View(listMahasiswa);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var mahasiswa = await _repositoriMahasiswa.Get(id);

            if(mahasiswa == null)
                return NotFound("Mahasiswa tidak ditemukan");

            var model = new EditMahasiswaVM
            {
                Id = mahasiswa.Id,
                NamaLengkap = mahasiswa.NamaLengkap,
                StatusAkun = mahasiswa.StatusAkun,
                Admin = await _userManager.IsInRoleAsync(mahasiswa, "Admin")
            };

            return View(model);
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
            await _repositoriMahasiswa.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
