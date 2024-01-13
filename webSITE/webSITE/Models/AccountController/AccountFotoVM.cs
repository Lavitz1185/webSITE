using System.ComponentModel.DataAnnotations;

namespace webSITE.Models.Account
{
    public class AccountFotoVM
    {
        [Required]
        [Display(Name = "Foto Profil")]
        public IFormFile FotoFormFile { get; set; }
    }
}
