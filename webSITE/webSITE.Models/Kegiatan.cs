using System;
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
        public DateTime TanggalMulai { get; set; }
        public DateTime TanggalBerakhir { get; set; }
        public string TempatKegiatan { get; set; }
        public string Keterangan { get; set; }

        public IList<Foto>? DaftarFoto { get; set; }
        public IList<Mahasiswa> DaftarMahasiswa { get; set; }
        public IList<PesertaKegiatan> DaftarPesertaKegiatan { get; set; }
    }
}
