namespace webSITE.Models.FotoController
{
    public class FotoViewModel
    {
        public string OrderBy { get; set; }
        public string Key { get; set; }
        public IList<Foto> DaftarFoto { get; set; }
    }
}
