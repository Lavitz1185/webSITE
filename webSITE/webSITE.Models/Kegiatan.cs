﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Models
{
    public class Kegiatan
    {
        public int Id { get; set; }
        public string NamaKegiatan { get; set; }
        public DateTime Tanggal { get; set; }
        public int LamaKegiatan { get; set; }
        public string Deskripsi { get; set; }

        public IList<Album>? DaftarAlbum { get; set; }
    }
}
