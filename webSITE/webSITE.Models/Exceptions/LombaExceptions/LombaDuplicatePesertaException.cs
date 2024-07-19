using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.LombaExceptions
{
    public class LombaDuplicatePesertaException : DomainException
    {
        public LombaDuplicatePesertaException(string message) : base(message)
        {
        }
    }
}
