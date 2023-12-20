﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Models
{
    public class Album
    {
        public string Id { get; set; }
        public DateTime Tanggal { get; set; }
        public string PhotoPath { get; set; }
        public int? IdKegiatan { get; set; }

        public Kegiatan? Kegiatan { get; set; }
    }
}
