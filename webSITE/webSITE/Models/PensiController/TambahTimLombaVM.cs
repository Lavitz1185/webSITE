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

    public List<TambahPesertaVM> AnggotaTim { get; set; } = new List<TambahPesertaVM>();
}
