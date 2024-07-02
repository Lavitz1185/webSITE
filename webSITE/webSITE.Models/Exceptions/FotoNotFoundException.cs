using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Exceptions.Abstraction;

namespace webSITE.Domain.Exceptions
{
    public class FotoNotFoundException : NotFoundException<Foto, int>
    {
        public FotoNotFoundException(int id) : base(id, nameof(Foto.Id))
        {
        }

        public FotoNotFoundException(string message) : base(message)
        {
        }
    }
}
