using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Exceptions.Abstraction;

namespace webSITE.Domain.Exceptions
{
    public class PesertaKegiatanNotFoundException : NotFoundException<PesertaKegiatan, int, string>
    {
        public PesertaKegiatanNotFoundException(string message) : base(message)
        {
        }

        public PesertaKegiatanNotFoundException(int idKegiatan, string idMahasiswa) 
            : base(idKegiatan, idMahasiswa, nameof(PesertaKegiatan.IdKegiatan), nameof(PesertaKegiatan.IdMahasiswa))
        {
        }
    }
}
