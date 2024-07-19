using webSITE.Domain.Abstractions;
using webSITE.Domain.Enum;
using webSITE.Domain.ValueObjects;

namespace webSITE.Domain
{
    public class TimLomba : Entity
    {
        public string NamaTim { get; set; } = string.Empty;
        public Angkatan Angkatan { get; set; }
        public DateTime TanggalDaftar { get; set; }
        public NoWa NoWaPerwakilan { get => AnggotaTim.First().NoWa; }

        public List<PesertaLomba> AnggotaTim { get; set; } = new();
    }
}
