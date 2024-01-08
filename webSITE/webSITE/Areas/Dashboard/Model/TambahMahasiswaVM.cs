using System.ComponentModel.DataAnnotations;
using webSITE.Models;

namespace webSITE.Areas.Dashboard.Model
{
    public class TambahMahasiswaVM
    {
        [Required(ErrorMessage = "")]
        public string Nim { get; set; }
        public string NamaLengkap { get; set; }
        public string NamaPanggilan { get; set; }
        public DateTime TanggalLahir { get; set; }
        public JenisKelamin JenisKelamin { get; set; }
        public string PhotoPath { get; set; }
    }
}
