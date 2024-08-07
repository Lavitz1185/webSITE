using System.ComponentModel.DataAnnotations;

namespace webSITE.Models.AccountController
{
    public class UbahEmailVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Email Baru")]
        [EmailAddress(ErrorMessage = "Format Email Salah")]
        [Required(ErrorMessage = "{0} harus diisi")]
        public string EmailBaru { get; set; } = string.Empty;
    }
}
