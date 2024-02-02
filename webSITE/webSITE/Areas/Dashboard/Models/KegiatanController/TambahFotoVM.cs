namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class TambahFotoVM
    {
        public int IdKegiatan { get; set; }

        public string NextUrl { get; set; }

        public List<FotoTambahFotoVM> FotoTanpaKegiatan { get; set; }
        public FotoBaruTambahFotoVM FotoBaru { get; set; }
    }
}
