using System.ComponentModel.DataAnnotations;
using webSITE.Domain.Enum;

namespace webSITE.Areas.Dashboard.Models.PensiController;

public class TambahVM
{
    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Nama { get; set; } = string.Empty;

    [Display(Name = "Jenis Lomba")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public JenisLomba Jenis { get; set; }

    [Display(Name = "Link Grup WA")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [Url(ErrorMessage = "{0} bukan URL yang valid")]
    public string LinkGrupWa { get; set; } = string.Empty;

    [Display(Name = "File PDF")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public IFormFile FilePDF { get; set; }

    [Display(Name = "Foto Lomba")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int FotoId { get; set; }

    [Display(Name = "Maksimal Kuota Per Angkatan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [Range(1, 100, ErrorMessage = "{0} harus diantara {1} dan {2}")]
    public int MaksKuotaPerAngkatan { get; set; } = 1;

    [Display(Name = "Jumlah Minimal Anggota Per Tim")]
    [Range(1, 100, ErrorMessage = "{0} harus diantara {1} dan {2}")]
    public int? MinAnggotaPerTim { get; set; } = 1;

    [Display(Name = "Jumlah Maksimal Anggota Per Tim")]
    [Range(1, 100, ErrorMessage = "{0} harus diantara {1} dan {2}")]
    public int? MaksAnggotaPerTim { get; set; } = 1;

    [Display(Name = "Pasangan Wajib Beda Jenis Kelamin")]
    public bool PasanganBedaJenisKelamin { get; set; }
}
