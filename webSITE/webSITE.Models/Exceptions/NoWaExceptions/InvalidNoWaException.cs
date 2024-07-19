using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.NoWaExceptions
{
    public class InvalidNoWaException : DomainException
    {
        public InvalidNoWaException(string message) : base(message)
        {
        }
    }
}
