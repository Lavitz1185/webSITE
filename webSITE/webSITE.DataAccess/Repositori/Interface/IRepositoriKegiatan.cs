using webSITE.Domain;
using webSITE.DataAccess.Repositori.Commons;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriKegiatan : IBaseRepositori<Kegiatan>
    {
        Task<List<Kegiatan>> GetAllByNamaKegiatan(string namaKegiatan);

        Task<Kegiatan> AddMahasiswa(string idMahasiswa, int idKegiatan);
        Task<Kegiatan> RemoveMahasiswa(string idMahasiswa, int idKegiatan);

        Task<Kegiatan> AddFoto(int idFoto, int idKegiatan);
        Task<Kegiatan> RemoveFoto(int idFoto, int idKegiatan);
    }
}
