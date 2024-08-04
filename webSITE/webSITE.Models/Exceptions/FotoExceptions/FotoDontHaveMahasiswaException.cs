using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.FotoExceptions
{
    public class FotoDontHaveMahasiswaException : DomainException
    {
        public FotoDontHaveMahasiswaException(string nim)
            : base($"Foto tidak memiliki Mahasiswa dengan NIM : {nim}")
        {
        }
    }
}
