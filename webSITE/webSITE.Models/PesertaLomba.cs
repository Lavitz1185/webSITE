using webSITE.Domain.Abstractions;
using webSITE.Domain.Enum;
using webSITE.Domain.Exceptions.NimExceptions;
using webSITE.Domain.ValueObjects;

namespace webSITE.Domain
{
    public class PesertaLomba : Entity
    {
        public Nim Nim { get; set; }
        public string Nama { get; set; }
        public JenisKelamin JenisKelamin { get; set; }
        public Angkatan Angkatan { get; set; }
        public NoWa NoWa { get; set; }
        public DateTime TanggalDaftar { get; set; }

        private PesertaLomba(
            Nim nim,
            string nama,
            JenisKelamin jenisKelamin,
            Angkatan angkatan,
            NoWa noWa,
            DateTime tanggalDaftar)
        {
            Nim = nim;
            Nama = nama;
            JenisKelamin = jenisKelamin;
            Angkatan = angkatan;
            NoWa = noWa;
            TanggalDaftar = tanggalDaftar;
        }

        public static PesertaLomba Create(
            Nim nim,
            string nama,
            JenisKelamin jenisKelamin,
            Angkatan angkatan,
            NoWa noWa,
            DateTime tanggalDaftar)
        {
            var kodeAngkatan = ((int)angkatan).ToString().Substring(2, 2);
            if (!nim.Value.StartsWith(kodeAngkatan))
                throw new InvalidNimException(
                    "Kode angkatan pada NIM tidak sesuai dengan angkatan");

            return new PesertaLomba(
                nim, 
                nama,
                jenisKelamin,
                angkatan,
                noWa,
                tanggalDaftar);
        }
    }
}
