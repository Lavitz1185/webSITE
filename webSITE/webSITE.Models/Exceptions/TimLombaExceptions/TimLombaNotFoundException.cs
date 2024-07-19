using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.TimLombaExceptions
{
    public class TimLombaNotFoundException : NotFoundException<TimLomba, int>
    {
        public TimLombaNotFoundException(string message) : base(message)
        {
        }

        public TimLombaNotFoundException(int id, string keyName) : base(id, keyName)
        {
        }
    }
}
