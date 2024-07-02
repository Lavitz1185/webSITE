using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Exceptions.Abstraction;

namespace webSITE.Domain.Exceptions
{
    public class MahasiswaDuplicateNimException : DomainException
    {
        public MahasiswaDuplicateNimException(string nim) : base($"Mahasiswa dengan NIM : {nim} sudah ada")
        {
        }
    }
}
