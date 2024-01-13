using System.ComponentModel.DataAnnotations;

namespace webSITE.Models.Account
{
    public class AccountIndexVM
    {
        [Required]
        [StringLength(10, ErrorMessage = "Panjang {0} minimal {2}", MinimumLength = 10)]
        [Display(Name = "NIM")]
        public string Nim { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Panjang {0} minimal {2} dan maksimal {1}", MinimumLength = 6)]
        [Display(Name = "Nama Lengkap")]
        public string NamaLengkap { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Panjang {0} minimal {2} dan maksimal {1}", MinimumLength = 1)]
        [Display(Name = "Nama Panggilan")]
        public string NamaPanggilan { get; set; }

        [Required]
        [Display(Name = "Tanggal Lahir")]
        public DateTime TanggalLahir { get; set; }

        [Required]
        [Display(Name = "Jenis Kelamin")]
        public JenisKelamin JenisKelamin { get; set; }
    }
}
