using System.ComponentModel.DataAnnotations;

namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class FotoBaruTambahFotoVM
    {
        [Display(Name = "File Foto")]
        public IFormFile? FotoFormFile { get; set; }

        [Display(Name = "Tanggal Foto")]
        public DateTime Tanggal { get; set; }

        public List<MahasiswaTambahFotoVM> DaftarMahasiswa { get; set; }
    }
}
