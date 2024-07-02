using System.ComponentModel.DataAnnotations;

namespace webSITE.Areas.Dashboard.Models.PengumumanController
{
    public class EditVM
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} harus diisi")]
        public string Judul { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} harus diisi")]
        public string Isi { get; set; } = string.Empty;

        [Display(Name = "Foto Baru")]
        public IFormFile? FotoBaru { get; set; }
    }
}
