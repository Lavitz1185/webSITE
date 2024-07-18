using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Domain.Abstractions
{
    public abstract class NotFoundException<T, TKey> : DomainException
    {
        protected NotFoundException(TKey id, string keyName) :
            base($"{nameof(T)} dengan {keyName} : {id} tidak ditemukan")
        {
        }

        public NotFoundException(string message) : base(message) { }
    }
}
