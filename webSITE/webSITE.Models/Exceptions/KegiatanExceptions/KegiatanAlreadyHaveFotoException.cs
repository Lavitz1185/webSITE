using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.KegiatanExceptions
{
    public class KegiatanAlreadyHaveFotoException : DomainException
    {
        public KegiatanAlreadyHaveFotoException(int idFoto)
            : base($"Kegiatan sudah memiliki foto dengan id : {idFoto}")
        {
        }
    }
}
