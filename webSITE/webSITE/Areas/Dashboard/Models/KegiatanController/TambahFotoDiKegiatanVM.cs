namespace webSITE.Areas.Dashboard.Models.KegiatanController
{
    public class TambahFotoDiKegiatanVM
    {
        public int IdKegiatan { get; set; }

        public string NextUrl { get; set; }

        public List<FotoTambahFotoDiKegiatanVM> FotoTanpaKegiatan { get; set; }
        public FotoBaruTambahFotoDiKegiatanVM FotoBaru { get; set; }
    }
}
