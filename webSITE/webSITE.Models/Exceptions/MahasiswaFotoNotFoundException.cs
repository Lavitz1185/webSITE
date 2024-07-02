using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Exceptions.Abstraction;

namespace webSITE.Domain.Exceptions
{
    public class MahasiswaFotoNotFoundException : NotFoundException<MahasiswaFoto, int, string>
    {
        public MahasiswaFotoNotFoundException(string message) : base(message)
        {
        }

        public MahasiswaFotoNotFoundException(int idFoto, string idMahasiswa) 
            : base(idFoto, idMahasiswa, nameof(MahasiswaFoto.IdFoto), nameof(MahasiswaFoto.IdMahasiswa))
        {
        }
    }
}
