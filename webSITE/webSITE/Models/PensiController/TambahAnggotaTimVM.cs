using System.ComponentModel.DataAnnotations;
using webSITE.Domain.Enum;

namespace webSITE.Models.PensiController;

public class TambahAnggotaTimVM
{
    [Display(Name = "NIM")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Nim { get; set; } = string.Empty;

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Nama { get; set; } = string.Empty;

    [Display(Name = "Jenis Kelamin")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public JenisKelamin JenisKelamin { get; set; }
}
