using System.ComponentModel.DataAnnotations;

namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class TambahKegiatanVM
    {
        [Display(Name = "Nama Kegiatan")]
        [Required(ErrorMessage = "{0} harud diisi")]
        public string NamaKegiatan { get; set; }

        [Display(Name = "Tanggal Mulai")]
        [Required(ErrorMessage = "{0} harud diisi")]
        public DateTime TanggalMulai { get; set; }

        [Display(Name = "Tanggal Berakhir")]
        [Required(ErrorMessage = "{0} harud diisi")]
        public DateTime TanggalBerakhir { get; set; }

        [Display(Name = "Tempat Kegiatan")]
        [Required(ErrorMessage = "{0} harud diisi")]
        public string TempatKegiatan { get; set; }

        [Display(Name = "Keterangan")]
        [Required(ErrorMessage = "{0} harud diisi")]
        public string Keterangan { get; set; }
    }
}
