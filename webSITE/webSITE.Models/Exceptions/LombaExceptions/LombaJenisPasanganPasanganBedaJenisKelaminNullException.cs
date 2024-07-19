using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.LombaExceptions
{
    public class LombaJenisPasanganPasanganBedaJenisKelaminNullException : DomainException
    {
        public LombaJenisPasanganPasanganBedaJenisKelaminNullException()
            : base("Lomba berjenis Lomba Berpasangan harus memiliki pilihan apakah harus pasangan beda jenis kelamin")
        {
        }
    }
}
