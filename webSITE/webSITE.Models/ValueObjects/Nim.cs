using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;
using webSITE.Domain.Exceptions.NimExceptions;

namespace webSITE.Domain.ValueObjects
{
    public class Nim : ValueObject
    {
        public string Value { get; }

        private Nim(string nim)
        {
            Value = nim;
        }

        public static Nim Create(string nim)
        {
            if (string.IsNullOrEmpty(nim))
                throw new InvalidNimException("Nim kosong");
            if (!Regex.IsMatch(nim, @"^[0-9]+$"))
                throw new InvalidNimException("Nim bukan angka");
            if (nim.Length != 10)
                throw new InvalidNimException("Panjang nim harus 10");
            if (!nim.Contains("0608"))
                throw new InvalidNimException("Kode prodi dan kode fakultas tidak valid untuk profi Ilkom dan FST");

            return new Nim(nim);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
