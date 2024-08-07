using System.ComponentModel.DataAnnotations;
using webSITE.Domain;

namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class TambahKegiatanVM
    {
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
        [MinLength(Kegiatan.MinKeteranganLength, ErrorMessage = "Panjang {0} minimal {1} karakter")]
        public string Keterangan { get; set; } = string.Empty;

        [Display(Name = "Foto Thumbnail")]
        [Required(ErrorMessage = "{0} harus dipilih")]
        public int IdThumbnail { get; set; }

        [Display(Name = "Album Foto")]
        [Required(ErrorMessage = "{0} harus dipilih")]
        [MinLength(1, ErrorMessage = "Kegiatan harus memiliki minimal 1 {0}")]
        [MaxLength(12, ErrorMessage = "Maksimal foto adalah {0}")]
        public List<int> DaftarIdFoto { get; set; } = new();

        [Display(Name = "Mahasiswa")]
        [Required(ErrorMessage = "{0} harus dipilih")]
        [MinLength(1, ErrorMessage = "Kegiatan harus memiliki minimal 1 {0}")]
        public List<string> DaftarIdMahasiswa { get; set; } = new();
    }
}
