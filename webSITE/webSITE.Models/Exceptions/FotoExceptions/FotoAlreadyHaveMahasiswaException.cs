using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.FotoExceptions
{
    public class FotoAlreadyHaveMahasiswaException : DomainException
    {
        public FotoAlreadyHaveMahasiswaException(string nim) :
            base($"Foto sudah memiliki Mahasiswa dengan NIM : {nim}")
        {
        }
    }
}
