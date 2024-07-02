using webSITE.Domain;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriPesertaKegiatan
    {
        Task Add(string idMahasiswa, int idKegiatan);
        Task Delete(string idMahasiswa, int idKegiatan);
    }
}
