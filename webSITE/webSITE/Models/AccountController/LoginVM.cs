using System.ComponentModel.DataAnnotations;

namespace webSITE.Models.AccountController
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Masukan Email")]
        [EmailAddress(ErrorMessage = "Format Email Salah")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Masukan Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
