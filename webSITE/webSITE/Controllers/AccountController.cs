﻿using AutoMapper;
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
using NuGet.Common;
using System.ComponentModel.DataAnnotations;
using webSITE.Configuration;
using Microsoft.Extensions.Options;

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
        private readonly INotificationService _notificationService;

        private readonly PhotoFileSettings _photoFileSettings;

        public AccountController(
            UserManager<Mahasiswa> userManager,
            IRepositoriMahasiswa repositoriMahasiswa,
            IMapper mapper,
            IUserStore<Mahasiswa> userStore,
            SignInManager<Mahasiswa> signInManager,
            ILogger<AccountController> logger,
            IMailService mailService,
            INotificationService notificationService,
            IOptions<PhotoFileSettings> options)
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
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Ubah Profil Gagal",
                });
            }

            _notificationService.AddNotification(new ToastrNotification
            {
                Type = ToastrNotificationType.Success,
                Title = "Ubah Profil Sukses",
            });

            return RedirectToAction("Index");
        }

        public IActionResult FotoProfil()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FotoProfil(AccountFotoVM accountFotoVM)
        {
            var id = _userManager.GetUserId(User);

            var mahasiswa = await _repositoriMahasiswa.Get(id);

            var photoData = await FileHelpers.ProcessFormFile<AccountFotoVM>(accountFotoVM.FotoFormFile
                , ModelState, _photoFileSettings.PermittedExtension, _photoFileSettings.FileSizeLimit);

            if (!ModelState.IsValid)
            {
                TempData["status"] = false;
                return View(accountFotoVM);
            }

            mahasiswa = await _repositoriMahasiswa.SetProfilePicture(mahasiswa.Id, photoData);

            if (mahasiswa == null)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Ubah Foto Profil Gagal"
                });

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
                ModelState.AddModelError("EmailBaru", "Email baru sama dengan email");
                return View(ubahEmailVM);
            }

            if (userSameEmail != user && userSameEmail != null)
            {
                ModelState.AddModelError("EmailBaru", "Email sudah digunakan");
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
                EmailBody = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."
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
                EmailBody = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."
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
        public IActionResult Daftar(string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Home", new { Area = "" });

            if (_signInManager.IsSignedIn(User))
                return Redirect(returnUrl);

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
                    var callbackUrl = Url.Action(
                        action: nameof(ConfirmEmail),
                        controller: "Account",
                        values: new { Area = "", userId, code },
                        protocol: Request.Scheme);

                    var success = await _mailService.SendMailAsync(new MailData
                    {
                        EmailToName = user.NamaLengkap,
                        EmailToId = registerVM.Email,
                        EmailSubject = "Confirm Your Email",
                        EmailBody = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."
                    });

                    if (success)
                        _notificationService.AddNotification(new ToastrNotification
                        {
                            Type = ToastrNotificationType.Success,
                            Title = "Email Verifikasi Terkirim",
                            Message = "Silahkan cek kotak masuk email anda"
                        });
                    else
                        _notificationService.AddNotification(new ToastrNotification
                        {
                            Type = ToastrNotificationType.Error,
                            Title = "Email Verifikasi Tidak Terkirim",
                            Message = "Coba kirirm ulang"
                        });

                    await _userManager.AddToRoleAsync(user, "Mahasiswa");

                    return RedirectToAction(nameof(SuccessRegistration), new { Area = "", userId });
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
        public IActionResult SuccessRegistration(string userId)
        {
            ViewData["UserId"] = userId;

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SuccessRegistrationPOST(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Action(
                action: nameof(ConfirmEmail),
                controller: "Account",
                values: new { Area = "", userId = userId, code = code },
                protocol: Request.Scheme);

            var success = await _mailService.SendMailAsync(new MailData
            {
                EmailToName = user.NamaLengkap,
                EmailToId = user.Email,
                EmailSubject = "Confirm Your Email",
                EmailBody = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."
            });

            if (success)
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Email Verifikasi Terkirim",
                    Message = "Silahkan cek kotak masuk email anda"
                });
            else
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Email Verifikasi Tidak Terkirim",
                    Message = "Coba kirirm ulang"
                });

            return RedirectToAction(
                actionName: nameof(SuccessRegistration),
                routeValues: new { Area = "", userId });
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Akun Tidak Ditemukan"
                });

                return RedirectToAction("Index", "Home");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded == false)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Konfirmasi Gagal"
                });

                return RedirectToAction(nameof(SuccessRegistration), new { Area = "", userId });
            }

            return View(nameof(ConfirmEmail));
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

                if (user.StatusAkun == StatusAkun.TidakAktif)
                {
                    ModelState.AddModelError(string.Empty, "Status akun tidak aktif");
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
