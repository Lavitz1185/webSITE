using System.ComponentModel.DataAnnotations;
using webSITE.Domain;

namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class EditKegiatanVM
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Nama Kegiatan")]
        [Required(ErrorMessage = "{0} harus diisi")]
        public string NamaKegiatan { get; set; } = string.Empty;

        [Display(Name = "Tanggal")]
        [Required(ErrorMessage = "{0} harus diisi")]
        public DateTime Tanggal { get; set; }

        [Display(Name = "Jumlah Hari")]
        [Required(ErrorMessage = "{0} harus diisi")]
        [Range(1, 200, ErrorMessage = "{0} antara {1} dan {2}")]
        public int JumlahHari { get; set; }

        [Display(Name = "Tempat Kegiatan")]
        [Required(ErrorMessage = "{0} harus diisi")]
        public string TempatKegiatan { get; set; } = string.Empty;

        [Display(Name = "Keterangan")]
        [Required(ErrorMessage = "{0} harus diisi")]
        [StringLength(500, MinimumLength = 100, ErrorMessage = "Panjang {0} minimal {2} karakter dan maksimal {1} karakter")]
        public string Keterangan { get; set; } = string.Empty;

        [Display(Name = "Foto Thumbnail")]
        [Required(ErrorMessage = "{0} harus dipilih")]
        public int? IdThumbnail { get; set; }

        [Display(Name = "Daftar Foto")]
        [Required]
        public List<int> DaftarIdFoto { get; set; } = new();

        [Display(Name = "Daftar Peserta")]
        [Required]
        public List<string> DaftarIdMahasiswa { get; set; } = new();
    }
}
