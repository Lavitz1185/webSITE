using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions
{
    public class PesertaKegiatanNotFoundException : DomainException
    {
        public PesertaKegiatanNotFoundException(int idKegiatan, string idMahasiswa) 
            : base($"Kegiatan dengan ID : {idKegiatan} tidak ada peserta dengan ID : {idMahasiswa}")
        {
        }
    }
}
