using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions
{
    public class PengumumanNotFoundException : NotFoundException<Pengumuman, int>
    {
        public PengumumanNotFoundException(string message) : base(message)
        {
        }

        public PengumumanNotFoundException(int id) : base(id, nameof(Pengumuman.Id))
        {
        }
    }
}
