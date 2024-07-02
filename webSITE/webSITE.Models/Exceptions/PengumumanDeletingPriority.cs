using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Exceptions.Abstraction;

namespace webSITE.Domain.Exceptions
{
    public class PengumumanDeletingPriority : DomainException
    {
        public PengumumanDeletingPriority() 
            : base("Pengumuman Prioritas tidak dapat dihapus. Coba ubah prioritas terlebih dahulu")
        {
        }
    }
}
