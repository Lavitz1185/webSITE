using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public DateTime Tanggal { get; set; }
        public string PhotoPath { get; set; }
        public int? IdKegiatan { get; set; }

        public Kegiatan? Kegiatan { get; set; }
        public IList<Mahasiswa> DaftarMahasiswa { get; set; }
        public IList<MahasiswaFoto> DaftaMahasiswaFoto { get; set; }
    }
}
