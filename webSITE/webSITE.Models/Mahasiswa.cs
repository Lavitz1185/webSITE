using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Enum;

namespace webSITE.Domain
{
    public class Mahasiswa : IdentityUser
    {
        public string Nim { get; set; } = string.Empty;
        public string NamaLengkap { get; set; } = string.Empty;
        public string NamaPanggilan { get; set; } = string.Empty;
        public DateTime TanggalLahir { get; set; }
        public JenisKelamin JenisKelamin { get; set; }
        public byte[] FotoProfil { get; set; } = Array.Empty<byte>(); 
        public string Bio { get; set; } = string.Empty;
        public StatusAkun StatusAkun { get; set; }
        public string StrJenisKelamin {
            get => JenisKelaminExtension.ToString(JenisKelamin);
        }
        public string StrStatus
        {
            get => StatusAkunExtension.ToString(StatusAkun);
        }

        public List<Kegiatan> DaftarKegiatan { get; set; } = new();
        public List<Foto> DaftarFoto { get; set; } = new();
    }
}
