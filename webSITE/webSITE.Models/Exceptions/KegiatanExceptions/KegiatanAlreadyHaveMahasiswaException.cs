using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.KegiatanExceptions
{
    public class KegiatanAlreadyHaveMahasiswaException : DomainException
    {
        public KegiatanAlreadyHaveMahasiswaException(int idKegiatan, string idMahasiswa)
            : base($"Kegiatan dengan ID : {idKegiatan} sudah memiliki peserta dengan ID : {idMahasiswa}")
        {
        }
    }
}
