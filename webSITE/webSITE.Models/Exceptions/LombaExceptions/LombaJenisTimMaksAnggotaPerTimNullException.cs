using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.LombaExceptions
{
    public class LombaJenisTimMaksAnggotaPerTimNullException : DomainException
    {
        public LombaJenisTimMaksAnggotaPerTimNullException()
            : base("Lomba dengan Jenis Lomba Tim harus memiliki maksimal anggota per tim")
        {
        }
    }
}
