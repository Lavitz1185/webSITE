using System.ComponentModel.DataAnnotations;
using webSITE.Domain.Enum;

namespace webSITE.Models.PensiController;

public class TambahPesertaVM
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

    [Display(Name = "Angkatan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Angkatan Angkatan { get; set; }

    [Display(Name = "Nomor Wa")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NoWa { get; set; } = string.Empty;
}
