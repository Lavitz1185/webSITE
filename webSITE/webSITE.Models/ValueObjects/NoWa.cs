using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;
using webSITE.Domain.Exceptions.NoWaExceptions;

namespace webSITE.Domain.ValueObjects
{
    public class NoWa : ValueObject
    {
        public string Value { get; }

        private NoWa(string noWa)
        {
            Value = noWa;
        }

        public static NoWa Create(string noWa)
        {
            if (string.IsNullOrEmpty(noWa))
                throw new InvalidNoWaException("Nomor WA kosong");
            if (!Regex.IsMatch(noWa, @"^[0-9]+$"))
                throw new InvalidNoWaException("Nomor WA bukan angka");
            if (noWa.Length != 12)
                throw new InvalidNoWaException("Panjang Nomor WA tidak sama dengan 12");

            return new NoWa(noWa);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
