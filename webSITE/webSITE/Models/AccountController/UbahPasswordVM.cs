using System.ComponentModel.DataAnnotations;

namespace webSITE.Models.AccountController
{
    public class UbahPasswordVM
    {
        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} harus diisi")]
        [DataType(DataType.Password)]
        public string Password { get ; set; }

        [Display(Name = "Password Baru")]
        [Required(ErrorMessage = "{0} harus diisi")]
        [DataType(DataType.Password)]
        public string PasswordBaru { get; set; }

        [Display(Name = "Konfirmasi Password Baru")]
        [DataType(DataType.Password)]
        [Compare(nameof(PasswordBaru), ErrorMessage = "{0} dan {1} tidak sama")]
        public string? KonfirmasiPassword { get; set; }
    }
}
