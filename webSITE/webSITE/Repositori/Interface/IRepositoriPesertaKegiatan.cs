using webSITE.Domain;

namespace webSITE.Repositori.Interface
{
    public interface IRepositoriPesertaKegiatan
    {
        Task<PesertaKegiatan> Create(string idMahasiswa, int idKegiatan);
        Task<PesertaKegiatan> Delete(string idMahasiswa, int idKegiatan);
    }
}
