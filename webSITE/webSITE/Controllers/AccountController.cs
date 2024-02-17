using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.Models.Account;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Utilities;
using webSITE.Models.AccountController;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using webSITE.Services.Contracts;
using webSITE.Models;

namespace webSITE.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<Mahasiswa> _userManager;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly IMapper _mapper;
        private readonly SignInManager<Mahasiswa> _signInManager;
        private readonly IUserStore<Mahasiswa> _userStore;
        private readonly IUserEmailStore<Mahasiswa> _emailStore;
        private readonly ILogger<AccountController> _logger;
        private readonly IMailService _mailService;

        private readonly long _sizeLimit;
        private readonly string[] _permittedExtension = new string[] { ".png", ".jpg", ".jpeg" };

        public AccountController(
            UserManager<Mahasiswa> userManager,
            IRepositoriMahasiswa repositoriMahasiswa,
            IConfiguration config,
            IMapper mapper,
            IUserStore<Mahasiswa> userStore,
            SignInManager<Mahasiswa> signInManager,
            ILogger<AccountController> logger,
            IMailService mailService)
        {
            _userManager = userManager;
            _repositoriMahasiswa = repositoriMahasiswa;
            _mapper = mapper;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;
            _mailService = mailService;
            _sizeLimit = config.GetValue<long>("FileSizeLimit");
        }

        public async Task<IActionResult> Index()
        {
            var id = _userManager.GetUserId(User);

            var mahasiswa = await _repositoriMahasiswa.Get(id);

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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FotoProfil(AccountFotoVM accountFotoVM)
        {
            var id = _userManager.GetUserId(User);

            var mahasiswa = await _repositoriMahasiswa.Get(id);

            var photoData = await FileHelpers.ProcessFormFile<AccountFotoVM>(accountFotoVM.FotoFormFile
                , ModelState, _permittedExtension, _sizeLimit);

            if (!ModelState.IsValid)
            {
                TempData["status"] = false;
                return View(accountFotoVM);
            }

            mahasiswa = await _repositoriMahasiswa.SetProfilePicture(mahasiswa.Id, photoData);

            if (mahasiswa == null)
            {
                ModelState.AddModelError(string.Empty, "Error Mengganti Foto Profil");
                TempData["status"] = false;
                return View(accountFotoVM);
            }

            TempData["status"] = true;
            return RedirectToAction("FotoProfil");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Daftar(string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Home", new { Area = "" });

            return View(new RegisterVM
            {
                ReturnUrl = returnUrl
            });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Daftar(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                user.Nim = registerVM.Nim;
                user.NamaLengkap = registerVM.NamaLengkap;
                user.NamaPanggilan = registerVM.NamaPanggilan;
                user.TanggalLahir = registerVM.TanggalLahir;
                user.JenisKelamin = registerVM.JenisKelamin;
                user.StatusAkun = StatusAkun.TidakAktif;

                string fotoProfilPath = @"wwwroot/img/student.png";
                user.FotoProfil = System.IO.File.ReadAllBytes(fotoProfilPath);

                var duplicate = await _repositoriMahasiswa.GetByNim(user.Nim);
                if (duplicate != null)
                {
                    ModelState.AddModelError("Nim", "NIM sudah digunakan");
                    return View(registerVM);
                }

                await _userManager.SetUserNameAsync(user, registerVM.Email);
                await _userManager.SetEmailAsync(user, registerVM.Email);
                var result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = registerVM.ReturnUrl },
                        protocol: Request.Scheme);

                    var success = await _mailService.SendMailAsync(new MailData
                    {
                        EmailToName = user.NamaLengkap,
                        EmailToId = registerVM.Email,
                        EmailSubject = "Confirm Your Email",
                        EmailBody = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."
                    });

                    if (success)
                        _logger.LogInformation("Email terkirim");
                    else
                        _logger.LogError("Email tidak terkirim");

                    await _userManager.AddToRoleAsync(user, "Mahasiswa");
                    return Content("Status Akun anda belum aktif. Akun anda akan direview terlebih dahulu.");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(registerVM);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            if (TempData["ErrorMessage"] is not null)
            {
                ModelState.AddModelError(string.Empty, TempData["ErrorMessage"] as string);
            }

            ViewData["ReturnUrl"] = returnUrl ?? Url.Action("Index", "Home", new { Area = "" });

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View(new LoginVM());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM, string? returnUrl = null)
        {
            returnUrl ??= Url.Action("Index", "Home", new { });
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true

                var user = await _userManager.FindByEmailAsync(loginVM.Email);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Akun dengan email ini tidak ditemukan");
                    return View(loginVM);
                }

                if (user.StatusAkun == StatusAkun.TidakAktif)
                {
                    ModelState.AddModelError(string.Empty, "Status akun tidak aktif");
                    return View(loginVM);
                }

                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login Gagal");
                    return View(loginVM);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(loginVM);
        }

        private Mahasiswa CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Mahasiswa>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Mahasiswa)}'. " +
                    $"Ensure that '{nameof(Mahasiswa)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
