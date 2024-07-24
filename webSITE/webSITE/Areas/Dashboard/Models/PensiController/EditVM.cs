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
}
