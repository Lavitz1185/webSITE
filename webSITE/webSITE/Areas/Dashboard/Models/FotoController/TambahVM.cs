using System.ComponentModel.DataAnnotations;

namespace webSITE.Areas.Dashboard.Models.FotoController
{
    public class TambahVM
    {
        [Required]
        [Display(Name = "Foto")]
        public IFormFile FormFile { get; set; }

        [Required]
        [Display(Name = "Dalam Foto")]
        public List<string> DaftarIdMahasiswa { get; set; } = new();
    }
}
