using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Areas.Dashboard.Models.MahasiswaController;
using webSITE.DataAccess.Data;
using webSITE.Models.Account;
using webSITE.Services.Contracts;
using webSITE.Models;

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
        private readonly IToastrNotificationService _notificationService;
        private readonly ILogger<MahasiswaController> _logger;

        public MahasiswaController(IRepositoriMahasiswa repositoriMahasiswa,
            UserManager<Mahasiswa> userManagaer,
            IUserStore<Mahasiswa> userStore,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger<MahasiswaController> logger,
            IToastrNotificationService notificationService)
        {
            _repositoriMahasiswa = repositoriMahasiswa;
            _userManager = userManagaer;
            _userStore = userStore;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var listMahasiswa = await _repositoriMahasiswa.GetAll();
            return View(listMahasiswa ?? new());
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (_userManager.GetUserId(User) == id)
                return BadRequest();

            var mahasiswa = await _repositoriMahasiswa.Get(id);

            if(mahasiswa is null)
                return NotFound();

            if(await _userManager.IsInRoleAsync(mahasiswa, "SUPERADMIN"))
                return BadRequest();

            var editMahasiswaVM = new EditMahasiswaVM
            {
                Id = mahasiswa.Id,
                NamaLengkap = mahasiswa.NamaLengkap,
                Bio = mahasiswa.Bio,
                InstagramProfileLink = mahasiswa.InstagramProfileLink?.ToString(),
                FacebookProfileLink = mahasiswa.FacebookProfileLink?.ToString(),
                TikTokProfileLink = mahasiswa.TikTokProfileLink?.ToString(),
            };
            
            editMahasiswaVM.Admin = await _userManager.IsInRoleAsync(mahasiswa, "Admin");

            return View(editMahasiswaVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMahasiswaVM editMahasiswaVM)
        {
            if (!ModelState.IsValid) return View(editMahasiswaVM);

            var mahasiswa = await _repositoriMahasiswa.Get(editMahasiswaVM.Id);

            if (mahasiswa is null) return NotFound();

            mahasiswa.Bio = editMahasiswaVM.Bio;

            if (editMahasiswaVM.InstagramProfileLink is not null)
            {
                var uri = new Uri(editMahasiswaVM.InstagramProfileLink);

                if (!uri.Host.Contains("instagram"))
                {
                    ModelState.AddModelError(
                        nameof(AccountIndexVM.InstagramProfileLink), "Bukan URL Instagram Valid");

                    return View(editMahasiswaVM);
                }

                mahasiswa.InstagramProfileLink = uri;
            }

            if (editMahasiswaVM.FacebookProfileLink is not null)
            {
                var uri = new Uri(editMahasiswaVM.FacebookProfileLink);

                if (!uri.Host.Contains("facebook"))
                {
                    ModelState.AddModelError(
                        nameof(AccountIndexVM.FacebookProfileLink), "Bukan URL Facebook Valid");

                    return View(editMahasiswaVM);
                }

                mahasiswa.FacebookProfileLink = uri;
            }

            if (editMahasiswaVM.TikTokProfileLink is not null)
            {
                var uri = new Uri(editMahasiswaVM.TikTokProfileLink);

                if (!uri.Host.Contains("tiktok"))
                {
                    ModelState.AddModelError(
                        nameof(AccountIndexVM.TikTokProfileLink), "Bukan URL Tiktok Valid");

                    return View(editMahasiswaVM);
                }

                mahasiswa.TikTokProfileLink = uri;
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,
                    "Error saat mengedit data mahasiswa. Message : {@message}. Time Stamp : {@timeStamp}",
                    ex.Message,
                    DateTime.Now);

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Gagal Menyimpan Perubahan!",
                    Message = "Laporkan masalah ke administrator"
                });

                return View(editMahasiswaVM);
            }

            if (editMahasiswaVM.Admin)
            {
                var result = await _userManager.AddToRoleAsync(mahasiswa, "Admin");

                if(!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);

                    return RedirectToAction("Edit");
                }
            }
            else
            {
                var result = await _userManager.RemoveFromRoleAsync(mahasiswa, "Admin");

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

            var mahasiswa = await _repositoriMahasiswa.Get(id);

            if(mahasiswa is null)
                return NotFound();

            if(await _userManager.IsInRoleAsync(mahasiswa, "SUPERADMIN"))
                return BadRequest();

            try
            {
                await _repositoriMahasiswa.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Delete. Message : {@message}, Time Stamp : {@dateTime}",
                    ex.Message, DateTime.Now);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(string id)
        {
            var mahasiswa = await _repositoriMahasiswa.GetWithDetail(id);

            if(mahasiswa is null)
                return NotFound();

            return View(mahasiswa);
        }
    }
}
