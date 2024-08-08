using System.ComponentModel.DataAnnotations;
using webSITE.CustomValidationAttribute;
using webSITE.Domain;
using webSITE.Domain.Enum;

namespace webSITE.Models.Account
{
    public class AccountIndexVM
    {
        [Required(ErrorMessage = "{0} harus diisi")]
        [StringLength(10, ErrorMessage = "Panjang {0} minimal {2}", MinimumLength = 10)]
        [Display(Name = "NIM")]
        public string Nim { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} harus diisi")]
        [StringLength(100, ErrorMessage = "Panjang {0} minimal {2} dan maksimal {1}", MinimumLength = 6)]
        [Display(Name = "Nama Lengkap")]
        public string NamaLengkap { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} harus diisi")]
        [StringLength(100, ErrorMessage = "Panjang {0} minimal {2} dan maksimal {1}", MinimumLength = 1)]
        [Display(Name = "Nama Panggilan")]
        public string NamaPanggilan { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} harus diisi")]
        [Display(Name = "Tanggal Lahir")]
        public DateTime TanggalLahir { get; set; }

        [Required(ErrorMessage = "{0} harus diisi")]
        [Display(Name = "Jenis Kelamin")]
        public JenisKelamin JenisKelamin { get; set; }

        [Required(ErrorMessage = "{0} harus diisi")]
        [MaxLength(Mahasiswa.MaxBioLength, ErrorMessage = "Maksimal panjang {0} harus {1}")]
        [SensorKataKasar]
        [Display(Name = "Bio")]
        public string Bio { get; set; } = string.Empty;

        [Display(Name = "Instagram")]
        [Url(ErrorMessage = "Bukan URL Valid")]
        public string? InstagramProfileLink { get; set; }

        [Display(Name = "Facebook")]
        [Url(ErrorMessage = "Bukan URL Valid")]
        public string? FacebookProfileLink { get; set; }

        [Display(Name = "Tiktok")]
        [Url(ErrorMessage = "Bukan URL Valid")]
        public string? TikTokProfileLink { get; set; }
    }
}
