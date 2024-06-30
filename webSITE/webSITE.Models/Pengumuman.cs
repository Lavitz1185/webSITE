using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Domain
{
    public class Pengumuman
    {
        public int Id { get; set; }
        public string Judul { get; set; }
        public string Isi { get; set; }
        public byte[] Foto { get; set; }
        public DateTime Tanggal { get; set; }
        public bool IsPriority { get; set; }
    }
}
