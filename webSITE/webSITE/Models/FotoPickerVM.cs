using webSITE.Domain;

namespace webSITE.Models
{
    public class FotoPickerVM
    {
        public List<Foto> DaftarFoto { get; set; } = new();
        public string Name { get; set; } = string.Empty;
        public bool Multi { get; set; }
        public List<int> DaftarIdFoto { get; set; } = new();
    }
}
