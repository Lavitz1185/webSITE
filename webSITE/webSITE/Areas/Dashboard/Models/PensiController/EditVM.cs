using System.ComponentModel.DataAnnotations;
using webSITE.Domain.Enum;

namespace webSITE.Areas.Dashboard.Models.PensiController;

public class EditVM
{
    [Required] 
    public int Id { get; set; }

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Nama { get; set; } = string.Empty;

    [Display(Name = "Keterangan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Keterangan { get; set; } = string.Empty;

    [Display(Name = "Link Grup WA")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [Url(ErrorMessage = "{0} bukan URL yang valid")]
    public string LinkGrupWa { get; set; } = string.Empty;

    [Display(Name = "Foto Lomba")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int? FotoId { get; set; }
}
