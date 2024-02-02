namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class FotoBaruTambahFotoVM
    {
        public IFormFile? FotoFormFile { get; set; }
        public DateTime Tanggal { get; set; }

        public List<MahasiswaTambahFotoVM> DaftarMahasiswa { get; set; }
    }
}
