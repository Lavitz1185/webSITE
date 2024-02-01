using System.ComponentModel.DataAnnotations;

namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class TambahKegiatanVM
    {
        [Display(Name = "Nama Kegiatan")]
        [Required(ErrorMessage = "{0} harus diisi")]
        public string NamaKegiatan { get; set; }

        [Display(Name = "Tanggal")]
        [Required(ErrorMessage = "{0} harus diisi")]
        public DateTime Tanggal { get; set; }

        [Display(Name = "Jumlah Hari")]
        [Required(ErrorMessage = "{0} harus diisi")]
        [Range(1, 200, ErrorMessage = "{0} antara {1} dan {2}")]
        public int JumlahHari { get; set; }

        [Display(Name = "Tempat Kegiatan")]
        [Required(ErrorMessage = "{0} harus diisi")]
        public string TempatKegiatan { get; set; }

        [Display(Name = "Keterangan")]
        [Required(ErrorMessage = "{0} harus diisi")]
        public string Keterangan { get; set; }
    }
}
