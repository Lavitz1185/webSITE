using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Exceptions.Abstraction;

namespace webSITE.Domain.Exceptions
{
    public class KegiatanAlreadyExistsException : DomainException
    {
        public KegiatanAlreadyExistsException(string namaKegiatan, DateTime tanggal) 
            : base($"Kegiatan dengan nama {namaKegiatan} dan tanggal {tanggal.ToShortDateString()} sudah ada")
        {
        }
    }
}
