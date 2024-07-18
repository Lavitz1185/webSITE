using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions
{
    public class PengumumanDeletingPriorityException : DomainException
    {
        public PengumumanDeletingPriorityException() 
            : base("Pengumuman Prioritas tidak dapat dihapus. Coba ubah prioritas terlebih dahulu")
        {
        }
    }
}
