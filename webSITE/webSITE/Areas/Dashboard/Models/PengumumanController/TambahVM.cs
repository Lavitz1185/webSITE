using System.ComponentModel.DataAnnotations;

namespace webSITE.Areas.Dashboard.Models.PengumumanController
{
    public class TambahVM
    {
        [Required(ErrorMessage = "{0} harus diisi")]
        public string Judul { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "{0} harus diisi")]
        public string Isi { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} harus diisi")]
        public int IdFoto { get; set; }
    }
}
