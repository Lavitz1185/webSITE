using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.KegiatanExceptions
{
    public class KegiatanDontHaveFotoException : DomainException
    {
        public KegiatanDontHaveFotoException(string namaKegiatan, int idFoto)
            : base($"Kegiatan {namaKegiatan} tidak punya Foto dengan Id : {idFoto}")
        {
        }
    }
}
