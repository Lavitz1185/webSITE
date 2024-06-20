﻿using System.ComponentModel.DataAnnotations;

namespace webSITE.Areas.Dashboard.Models.FotoController
{
    public class TambahFotoVM
    {
        [Required]
        [Display(Name = "Tanggal Foto")]
        public DateTime Tanggal { get; set; }

        [Required]
        [Display(Name = "Foto")]
        public IFormFile FotoFormFile { get; set; }

        [Display(Name = "Dalam Foto")]
        public List<MahasiswaTambahFotoVM> DaftarMahasiswaTambahFotoVM { get; set; }

        [Display(Name = "Kegiatan")]
        public int? IdKegiatan { get; set; }
    }
}
