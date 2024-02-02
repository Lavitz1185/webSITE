namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class TambahFotoVM
    {
        public int IdKegiatan { get; set; }

        public string NextUrl { get; set; }

        public List<(int IdFoto, bool DalamKegiatan)> FotoTanpaKegiatan { get; set; }
        public FotoTambahFotoVM FotoBaru { get; set; }
    }
}
