// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using webSITE.Models;
using webSITE.Repositori.Interface;

namespace webSITE.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Mahasiswa> _signInManager;
        private readonly UserManager<Mahasiswa> _userManager;
        private readonly IUserStore<Mahasiswa> _userStore;
        private readonly IUserEmailStore<Mahasiswa> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;

        public RegisterModel(
            UserManager<Mahasiswa> userManager,
            IUserStore<Mahasiswa> userStore,
            SignInManager<Mahasiswa> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IRepositoriMahasiswa repositoriMahasiswa)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _repositoriMahasiswa = repositoriMahasiswa;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Masukan {0}")]
            [EmailAddress(ErrorMessage = "Format {0} salah")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Masukan {0}")]
            [StringLength(100, ErrorMessage = "Panjang {0} minimanl {2} dan maksimal {1} karakater.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Konfirmasi password")]
            [Compare("Password", ErrorMessage = "Password dan konfirmasi password tidak sama.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Masukan {0}")]
            [StringLength(10, ErrorMessage = "Panjang {0} minimanl {2} dan maksimal {1} karakater.", MinimumLength = 10)]
            [Display(Name = "NIM")]
            public string Nim { get; set; }

            [Required(ErrorMessage = "Masukan {0}")]
            [StringLength(100, ErrorMessage = "Panjang {0} minimanl {2} dan maksimal {1} karakater.", MinimumLength = 6)]
            [Display(Name = "Nama Lengkap")]
            public string NamaLengkap { get; set; }

            [Required(ErrorMessage = "Masukan {0}")]
            [StringLength(100, ErrorMessage = "Panjang {0} minimanl {2} dan maksimal {1} karakater.", MinimumLength = 2)]
            [Display(Name = "Nama Panggilan")]
            public string NamaPanggilan{ get; set; }

            [Required(ErrorMessage = "Masukan {0}")]
            [DataType(DataType.Date)]
            [Display(Name = "Tanggal Lahir")]
            public DateTime TanggalLahir { get; init; } = new DateTime(2004, 1, 1);

            [Required(ErrorMessage = "Masukan {0}")]
            [Display(Name = "Jenis Kelamin")]
            public JenisKelamin JenisKelamin { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                user.Nim = Input.Nim;
                user.NamaLengkap = Input.NamaLengkap;
                user.NamaPanggilan = Input.NamaPanggilan;
                user.TanggalLahir = Input.TanggalLahir;
                user.JenisKelamin = Input.JenisKelamin;
                user.PhotoPath = "/img/LOGO_SITE-removebg-preview.png";

                var duplicate = await _repositoriMahasiswa.GetByNim(user.Nim);
                if(duplicate != null)
                {
                    ModelState.AddModelError(string.Empty, "NIM sudah digunakan");
                    return Page();
                }

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
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

        private IUserEmailStore<Mahasiswa> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Mahasiswa>)_userStore;
        }
    }
}
