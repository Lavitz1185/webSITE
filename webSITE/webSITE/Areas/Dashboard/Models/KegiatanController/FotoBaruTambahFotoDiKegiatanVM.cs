using System.ComponentModel.DataAnnotations;
using webSITE.Areas.Dashboard.Models.Shared;

namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class FotoBaruTambahFotoDiKegiatanVM
    {
        [Display(Name = "File Foto")]
        public IFormFile? FotoFormFile { get; set; }

        [Display(Name = "Tanggal Foto")]
        public DateTime Tanggal { get; set; }

        public List<MahasiswaIncludeVM> DaftarMahasiswa { get; set; }
    }
}
