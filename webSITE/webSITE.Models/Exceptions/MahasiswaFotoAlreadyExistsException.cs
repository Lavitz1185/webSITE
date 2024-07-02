using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Exceptions.Abstraction;

namespace webSITE.Domain.Exceptions
{
    public class MahasiswaFotoAlreadyExistsException : DomainException
    {
        public MahasiswaFotoAlreadyExistsException(int idFoto, string idMahasiswa) : 
            base($"MahasiswaFoto dengan IdMahasiswa : {idMahasiswa}, dan IdFoto : {idFoto} sudah ada")
        {
        }
    }
}
