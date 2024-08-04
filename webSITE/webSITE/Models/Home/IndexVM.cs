using webSITE.Domain;

namespace webSITE.Models.Home
{
    public class IndexVM
    {
        public List<Kegiatan> DaftarKegiatan { get; set; } = new();
        public List<Mahasiswa> DaftarMahasiswa { get; set; } = new();
    }
}
