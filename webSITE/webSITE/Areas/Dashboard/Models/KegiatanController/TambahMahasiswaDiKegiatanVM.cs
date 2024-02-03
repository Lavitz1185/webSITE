using webSITE.Areas.Dashboard.Models.Shared;

namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class TambahMahasiswaDiKegiatanVM
    {
        public int IdKegiatan { get ; set; }

        public string NamaKegiatan { get; set; }

        public DateTime Tanggal { get; set; }

        public List<string> NamaPesertaKegiatan { get; set; }

        public List<MahasiswaIncludeVM> DaftarPesertaBaru { get; set; }
    }
}
