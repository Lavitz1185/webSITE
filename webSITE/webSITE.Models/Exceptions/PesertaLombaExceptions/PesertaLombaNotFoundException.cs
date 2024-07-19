using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.PesertaLombaExceptions
{
    public class PesertaLombaNotFoundException : NotFoundException<PesertaLomba, int>
    {
        public PesertaLombaNotFoundException(string message) : base(message)
        {
        }

        public PesertaLombaNotFoundException(int id, string keyName) : base(id, keyName)
        {
        }
    }
}
