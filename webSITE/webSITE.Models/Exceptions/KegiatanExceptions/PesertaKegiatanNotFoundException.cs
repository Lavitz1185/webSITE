using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.KegiatanExceptions
{
    public class PesertaKegiatanNotFoundException : DomainException
    {
        public PesertaKegiatanNotFoundException(string nim)
            : base($"Kegiatan tidak memiliki peserta dengan NIM : {nim}")
        {
        }
    }
}
