using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Exceptions.Abstraction;

namespace webSITE.Domain.Exceptions
{
    public class PesertaKegiatanAlreadyExistsException : DomainException
    {
        public PesertaKegiatanAlreadyExistsException(int idKegiatan, string idMahasiswa) 
            : base($"Peserta Kegiatan dengan IdKegiatan : {idKegiatan} dan IdMahasiswa : {idMahasiswa} sudah ada")
        {
        }
    }
}
