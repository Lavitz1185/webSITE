using webSITE.Domain.Enum;

namespace webSITE.Models.PensiController;

public class TambahTimLombaVM
{
    public string NamaTim { get; set; } = string.Empty;
    public Angkatan Angkatan { get; set; }

    public TambahPesertaVM[] AnggotaTim { get; set; } = Array.Empty<TambahPesertaVM>();
}
