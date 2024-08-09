using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webSITE.Domain;
using webSITE.Models.Account;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Utilities;
using webSITE.Models.AccountController;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using webSITE.Services.Contracts;
using webSITE.Models;
using webSITE.Configuration;
using Microsoft.Extensions.Options;
using webSITE.DataAccess.Data;
using webSITE.Domain.Abstractions;

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
        private readonly ILogger<AccountController> _logger;
        private readonly IMailService _mailService;
        private readonly IToastrNotificationService _notificationService;
        private readonly IUnitOfWork _unitOfWork;

        private readonly PhotoFileSettingsOptions _photoFileSettings;

        public AccountController(
            UserManager<Mahasiswa> userManager,
            IRepositoriMahasiswa repositoriMahasiswa,
            IMapper mapper,
            IUserStore<Mahasiswa> userStore,
            SignInManager<Mahasiswa> signInManager,
            ILogger<AccountController> logger,
            IMailService mailService,
            IToastrNotificationService notificationService,
            IOptions<PhotoFileSettingsOptions> options,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _repositoriMahasiswa = repositoriMahasiswa;
            _mapper = mapper;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;
            _mailService = mailService;
            _notificationService = notificationService;
            _photoFileSettings = options.Value;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var id = _userManager.GetUserId(User);

            var mahasiswa = await _repositoriMahasiswa.Get(id);

            if(mahasiswa is null) return Forbid();

            var accountIndexVM = new AccountIndexVM
            {
                Nim = mahasiswa.Nim,
                NamaLengkap = mahasiswa.NamaLengkap,
                NamaPanggilan = mahasiswa.NamaPanggilan,
                JenisKelamin = mahasiswa.JenisKelamin,
                TanggalLahir = mahasiswa.TanggalLahir,
                Bio = mahasiswa.Bio,
                InstagramProfileLink = mahasiswa.InstagramProfileLink?.ToString(),
                FacebookProfileLink = mahasiswa.FacebookProfileLink?.ToString(),
                TikTokProfileLink = mahasiswa.TikTokProfileLink?.ToString()
            };

            return View(accountIndexVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AccountIndexVM accountIndexVM)
        {
            if (!ModelState.IsValid) return View(accountIndexVM);

            var mahasiswa = await _userManager.GetUserAsync(User);

            if(mahasiswa is null) return Forbid();

            mahasiswa.NamaLengkap = accountIndexVM.NamaLengkap;
            mahasiswa.NamaPanggilan = accountIndexVM.NamaPanggilan;
            mahasiswa.TanggalLahir = accountIndexVM.TanggalLahir;
            mahasiswa.Nim = accountIndexVM.Nim;
            mahasiswa.JenisKelamin = accountIndexVM.JenisKelamin;
            mahasiswa.Bio = accountIndexVM.Bio;

            if (accountIndexVM.InstagramProfileLink is not null)
            {
                var uri = new Uri(accountIndexVM.InstagramProfileLink);

                if (!uri.Host.Contains("instagram"))
                {
                    ModelState.AddModelError(
                        nameof(AccountIndexVM.InstagramProfileLink), "Bukan URL Instagram Valid");

                    return View(accountIndexVM);
                }

                mahasiswa.InstagramProfileLink = uri;
            }

            if (accountIndexVM.FacebookProfileLink is not null)
            {
                var uri = new Uri(accountIndexVM.FacebookProfileLink);

                if (!uri.Host.Contains("facebook"))
                {
                    ModelState.AddModelError(
                        nameof(AccountIndexVM.FacebookProfileLink), "Bukan URL Facebook Valid");

                    return View(accountIndexVM);
                }

                mahasiswa.FacebookProfileLink = uri;
            }

            if (accountIndexVM.TikTokProfileLink is not null)
            {
                var uri = new Uri(accountIndexVM.TikTokProfileLink);

                if (!uri.Host.Contains("tiktok"))
                {
                    ModelState.AddModelError(
                        nameof(AccountIndexVM.TikTokProfileLink), "Bukan URL Tiktok Valid");

                    return View(accountIndexVM);
                }

                mahasiswa.TikTokProfileLink = uri;
            }

            try
            {
                _repositoriMahasiswa.Update(mahasiswa);
                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Ubah Profil Sukses",
                });
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Ubah Profil Gagal",
                    Message = ex.Message,
                });

                _logger.LogError("Index. Exception : {0}", ex.ToString());
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Ubah Profil Gagal"
                });

                _logger.LogError("Index. Exception : {0}", ex.ToString());
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult FotoProfil()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FotoProfil(AccountFotoVM accountFotoVM)
        {
            var id = _userManager.GetUserId(User);

            var user = await _repositoriMahasiswa.Get(id);

            if (user is null) return NotFound();

            var permittedExtension = _photoFileSettings.PermittedExtension.ToList()
                .SkipWhile(s => s == ".png")
                .ToArray();

            var photoData = await FileHelpers.ProcessFormFile<AccountFotoVM>(accountFotoVM.FotoFormFile, 
                ModelState, permittedExtension, _photoFileSettings.FileSizeLimit);

            if (!ModelState.IsValid)
            {
                TempData["status"] = false;
                return View(accountFotoVM);
            }

            try
            {
                user.FotoProfil = photoData;
                _repositoriMahasiswa.Update(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Ubah Foto Profil Gagal",
                    Message = ex.Message
                });

                _logger.LogError("FotoProfil. Exception : {0}", ex.ToString());
                TempData["status"] = false;
                return View(accountFotoVM);
            }      
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Ubah Foto Profil Gagal"
                });

                _logger.LogError("FotoProfil. Exception : {0}", ex.ToString());
                TempData["status"] = false;
                return View(accountFotoVM);
            }

            _notificationService.AddNotification(new ToastrNotification
            {
                Type = ToastrNotificationType.Success,
                Title = "Ubah Foto Profil Berhasil"
            });

            TempData["status"] = true;

            return RedirectToAction(nameof(FotoProfil));
        }

        public IActionResult UbahPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UbahPassword(UbahPasswordVM ubahPasswordVM)
        {
            var user = await _userManager.GetUserAsync(User);

            //Validasi
            if (!(await _userManager.CheckPasswordAsync(user, ubahPasswordVM.Password)))
            {
                ModelState.AddModelError("Password", "Password salah");
                return View(ubahPasswordVM);
            }

            if (ubahPasswordVM.PasswordBaru == ubahPasswordVM.Password)
            {
                ModelState.AddModelError("PasswordBaru", "Password baru sama dengan password lama");
                return View(ubahPasswordVM);
            }

            //Ubah password
            var result = await _userManager.ChangePasswordAsync(user,
                                                                ubahPasswordVM.Password,
                                                                ubahPasswordVM.PasswordBaru);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(result => $"{result.Code} : {result.Description}");

                var errorString = string.Join("\n", errors);

                _logger.LogError(errorString);

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Ubah Password Gagal"
                });

                return View();
            }

            _notificationService.AddNotification(new ToastrNotification
            {
                Type = ToastrNotificationType.Success,
                Title = "Ubah Password Berhasil"
            });
            return View();
        }

        public async Task<IActionResult> UbahEmail()
        {
            var user = await _userManager.GetUserAsync(User);
            var email = user.Email;

            return View(new UbahEmailVM
            {
                Email = email
            });
        }

        [HttpPost]
        public async Task<IActionResult> UbahEmail(UbahEmailVM ubahEmailVM)
        {
            var user = await _userManager.GetUserAsync(User);
            var userSameEmail = await _userManager.FindByEmailAsync(ubahEmailVM.EmailBaru);

            //Validasi
            if (ubahEmailVM.Email == ubahEmailVM.EmailBaru)
            {
                ModelState.AddModelError(nameof(UbahEmailVM.EmailBaru), "Email baru sama dengan email");
                return View(ubahEmailVM);
            }

            if (userSameEmail != user && userSameEmail != null)
            {
                ModelState.AddModelError(nameof(UbahEmailVM.EmailBaru), "Email sudah digunakan");
                return View(ubahEmailVM);
            }

            //Kirim email verifikasi
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateChangeEmailTokenAsync(user, ubahEmailVM.EmailBaru);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Action(
                action: nameof(ConfirmChangeEmail),
                controller: "Account",
                values: new { Area = "", userId, code, email = ubahEmailVM.EmailBaru },
                protocol: Request.Scheme);

            var success = await _mailService.SendMailAsync(new MailData
            {
                EmailToName = user.NamaLengkap,
                EmailToId = ubahEmailVM.EmailBaru,
                EmailSubject = "Confirm Your Email",
                EmailBody = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl!)}'>clicking here</a>."
            });

            if (!success)
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Email verfikasi gagal terkirim silahkan coba lagi"
                });
            else
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Email verfikasi berhasil terkirim",
                    Message = "Silahkan cek kotak masuk email anda"
                });

            return RedirectToAction(nameof(UbahEmailTunggu), new { Area = "", email = ubahEmailVM.EmailBaru });
        }

        public IActionResult UbahEmailTunggu(string email)
        {
            ViewData["Email"] = email;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UbahEmailTungguPOST(string email)
        {
            ViewData["Email"] = email;

            var user = await _userManager.GetUserAsync(User);

            //Kirim email verifikasi
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateChangeEmailTokenAsync(user, email);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Action(
                action: nameof(ConfirmChangeEmail),
                controller: "Account",
                values: new { Area = "", userId, code, email },
                protocol: Request.Scheme);

            var success = await _mailService.SendMailAsync(new MailData
            {
                EmailToName = user.NamaLengkap,
                EmailToId = email,
                EmailSubject = "Confirm Your Email",
                EmailBody = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl!)}'>clicking here</a>."
            });

            if (!success)
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Email verfikasi gagal terkirim silahkan coba lagi"
                });
            else
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Email verfikasi berhasil terkirim",
                    Message = "Silahkan cek kotak masuk email anda"
                });

            return View(nameof(UbahEmailTunggu));
        }

        public async Task<IActionResult> ConfirmChangeEmail(string userId, string code, string email)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Verifikasi Email Gagal",
                    Message = "Akun tidak ditemukan"
                });

                return RedirectToAction("Index", "Home");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await _userManager.ChangeEmailAsync(user, email, code);

            if (result.Succeeded == false)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Ubah Email Gagal"
                });

                return RedirectToAction(nameof(UbahEmail));
            }

            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }        
        
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            returnUrl ??= Url.Action("Index", "Home", new { Area = "" });

            if (_signInManager.IsSignedIn(User))
                return Redirect(returnUrl);

            if (TempData["ErrorMessage"] is not null)
            {
                ModelState.AddModelError(string.Empty, TempData["ErrorMessage"] as string);
            }

            ViewData["ReturnUrl"] = returnUrl;

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View(new LoginVM());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM, string? returnUrl = null)
        {
            returnUrl ??= Url.Action("Index", "Home", new { Area = "" });
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginVM.Email);

                if (user == null)
                {
                    ModelState.AddModelError("Email", "Akun dengan email ini tidak ditemukan");
                    return View(loginVM);
                }

                if (user.EmailConfirmed == false)
                {
                    ModelState.AddModelError(string.Empty, "Login gagal");
                    return View(loginVM);
                }

                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");

                    _notificationService.AddNotification(new ToastrNotification
                    {
                        Type = ToastrNotificationType.Info,
                        Title = $"Selamat Datang Kembali {user.NamaPanggilan}!",
                        Message = "Semoga Kamu Betah"
                    });

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

        [HttpPost]
        public async Task<IActionResult> Logout(string? returnUrl = null)
        {
            returnUrl ??= Url.Action("Index", "Home", new { Area = "" });

            await _signInManager.SignOutAsync();

            return Redirect(returnUrl!);
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
