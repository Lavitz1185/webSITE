using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Domain
{
    public class Mahasiswa : IdentityUser
    {
        public string Nim { get; set; }
        public string NamaLengkap { get; set; }
        public string NamaPanggilan { get; set; }
        public DateTime TanggalLahir { get; set; }
        public JenisKelamin JenisKelamin { get; set; }
        public byte[] FotoProfil { get; set; }
        public string? Bio { get; set; }
        public StatusAkun StatusAkun { get; set; }
        public string StrJenisKelamin {
            get => JenisKelaminExtension.ToString(JenisKelamin);
        }
        public string StrStatus
        {
            get => StatusAkunExtension.ToString(StatusAkun);
        }

        public IList<Kegiatan> DaftarKegiatan { get; set; }
        public IList<Foto> DaftarFoto { get; set; }
    }
}
