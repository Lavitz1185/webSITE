using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Exceptions.Abstraction;

namespace webSITE.Domain.Exceptions
{
    public class KegiatanNotFoundException : NotFoundException<Kegiatan, int>
    {
        public KegiatanNotFoundException(int id) : base(id, "Id")
        {
        }

        public KegiatanNotFoundException(string message) : base(message)
        {
        }
    }
}
