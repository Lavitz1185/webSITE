using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using webSITE.Models.Identity;

namespace webSITE.Models
{
    public class Mahasiswa
    {
        public int Id { get; set; }
        public string Nim { get; set; }
        public string NamaLengkap { get; set; }
        public string NamaPanggilan { get; set; }
        public DateTime TanggalLahir { get; set; }
        public JenisKelamin JenisKelamin { get; set; }
        public string PhotoPath { get; set; }
        public string StrJenisKelamin { 
            get 
            {
                if (JenisKelamin == JenisKelamin.LakiLaki)
                    return "Laki - Laki";
                else
                    return "Perempuan";
            } 
        }

        public AppUser? AppUser { get; set; }
        public IList<Kegiatan> DaftarKegiatan { get; set; }
        public IList<Foto> DaftarFoto { get; set; }
    }
}
