using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Domain.Exceptions.Abstraction
{
    public abstract class NotFoundException<T, TKey> : DomainException
    {
        protected NotFoundException(TKey id, string keyName) : 
            base($"{nameof(T)} dengan {keyName} : {id} tidak ditemukan")
        {
        }

        public NotFoundException(string message) :base(message) { }
    }

    public abstract class NotFoundException<T, TKey1, TKey2> : DomainException
    {
        protected NotFoundException(TKey1 id1, TKey2 id2, string keyName1, string keyName2) :
            base($"{nameof(T)} dengan {keyName1} : {id1} dan {keyName2} : {id2} tidak ditemukan")
        {
        }

        public NotFoundException(string message) : base(message) { }
    }
}
