using webSITE.Domain;

namespace webSITE.Models
{
    public class MahasiswaPickerVM
    {
        public string Name { get; set; } = string.Empty;
        public bool Multi { get; set; }
        public List<Mahasiswa> DaftarMahasiswa { get; set; } = new();
        public List<string> DaftarIdMahasiswa { get; set; } = new();
    }
}
