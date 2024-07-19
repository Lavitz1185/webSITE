using webSITE.Domain;

namespace webSITE.Models.FotoController
{
    public class AlbumVM
    {
        public int? IdKegiatan { get ; set; }
        public string NamaKegiatan { get; set; } = string.Empty;
        public DateTime Tanggal { get; set; }
        public int? IdThumbnail { get; set; }
        public int JumlahFoto { get; set; }
        public List<Foto>? DaftarFoto { get; set; }
    }
}
