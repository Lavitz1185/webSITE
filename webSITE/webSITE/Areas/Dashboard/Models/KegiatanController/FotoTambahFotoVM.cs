namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class FotoTambahFotoVM
    {
        public IFormFile? FotoFormFile { get; set; }
        public DateTime Tanggal { get; set; }

        public List<(string IdMahasiswa, string NamaLengkap, bool DalamFoto)> DaftarMahasiswa { get; set; }
    }
}
