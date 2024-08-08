using System.ComponentModel.DataAnnotations;
using webSITE.CustomValidationAttribute;
using webSITE.Domain;

namespace webSITE.Areas.Dashboard.Models.MahasiswaController
{
    public class EditMahasiswaVM
    {
        public string Id { get; set; } = string.Empty;

        public string NamaLengkap { get; set; } = string.Empty;

        [Display(Name = "Admin")]
        public bool Admin { get; set; }

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
