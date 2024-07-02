using webSITE.Domain;
using webSITE.DataAccess.Repositori.Commons;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriKegiatan : IBaseRepositori<Kegiatan>
    {
        Task<List<Kegiatan>?> GetAllByNamaKegiatan(string namaKegiatan);

        Task AddMahasiswa(string idMahasiswa, int idKegiatan);
        Task RemoveMahasiswa(string idMahasiswa, int idKegiatan);

        Task AddFoto(int idFoto, int idKegiatan);
        Task RemoveFoto(int idFoto, int idKegiatan);
    }
}
