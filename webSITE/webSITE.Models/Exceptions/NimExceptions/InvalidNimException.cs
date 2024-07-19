using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.NimExceptions
{
    public class InvalidNimException : DomainException
    {
        public InvalidNimException(string message) : base(message)
        {
        }
    }
}
