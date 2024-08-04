using System.ComponentModel.DataAnnotations;
using webSITE.Domain.Enum;

namespace webSITE.Models.PensiController;

public class TambahTimLombaVM
{
    [Display(Name = "Nama Tim")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NamaTim { get; set; } = string.Empty;

    [Display(Name = "Angkatan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public Angkatan Angkatan { get; set; }

    [Display(Name = "Nomor Wa")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string NoWa { get; set; } = string.Empty;

    [Display(Name = "Setuju Ketentuan Lomba")]
    [Required(ErrorMessage = "Harus diisi")]
    [Compare(nameof(IsTrue), ErrorMessage = "Harus Dicentang")]
    public bool Setuju { get; set; }

    public bool IsTrue => true;

    public List<TambahAnggotaTimVM> AnggotaTim { get; set; } = new List<TambahAnggotaTimVM>();
}
