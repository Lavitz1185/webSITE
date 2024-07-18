using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions
{
    public class FotoAlreadyHaveMahasiswaException : DomainException
    {
        public FotoAlreadyHaveMahasiswaException(int idFoto, string idMahasiswa) : 
            base($"Didalam Foto dengan ID : {idFoto} sudah ada Mahasiswa dengan ID : {idMahasiswa}")
        {
        }
    }
}
