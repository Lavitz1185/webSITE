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
        public KegiatanAlreadyHaveMahasiswaException(string nim)
            : base($"Kegiatan sudah memiliki peserta dengan NIM : {nim}")
        {
        }
    }
}
