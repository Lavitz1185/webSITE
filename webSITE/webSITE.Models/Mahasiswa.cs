using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Models
{
    public class Mahasiswa : IdentityUser
    {
        public string Nim { get; set; }
        public string NamaLengkap { get; set; }
        public string NamaPanggilan { get; set; }
        public DateTime TanggalLahir { get; set; }
        public JenisKelamin JenisKelamin { get; set; }
        public string PhotoPath { get; set; }
        public string? Bio { get; set; }
        public StatusAkun StatusAkun { get; set; }
        public string StrJenisKelamin {
            get => JenisKelaminExtension.ToString(JenisKelamin);
        }

        public IList<Kegiatan> DaftarKegiatan { get; set; }
        public IList<Foto> DaftarFoto { get; set; }
    }

    public enum StatusAkun
    {
        Aktif,
        TidakAktif
    }
}
