using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions
{
    public class MahasiswaNotFoundException : NotFoundException<Mahasiswa, string>
    {
        public MahasiswaNotFoundException(string id) : base(id, nameof(Mahasiswa.Id))
        {
        }
    }
}
