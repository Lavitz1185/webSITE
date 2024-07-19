using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.MahasiswaExceptions
{
    public class MahasiswaDuplicateNimException : DomainException
    {
        public MahasiswaDuplicateNimException(string nim) : base($"Mahasiswa dengan NIM : {nim} sudah ada")
        {
        }
    }
}
