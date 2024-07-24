﻿using System.ComponentModel.DataAnnotations;
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

    [Display(Name = "Keterangan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string Keterangan { get; set; } = string.Empty;

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
