using webSITE.Domain;
using webSITE.Repositori.Commons;

namespace webSITE.Repositori.Interface
{
    public interface IRepositoriKegiatan : IBaseRepositori<Kegiatan>
    {
        Task<Kegiatan> AddMahasiswa(string idMahasiswa, int idKegiatan);
        Task<Kegiatan> RemoveMahasiswa(string idMahasiswa, int idKegiatan);

        Task<Kegiatan> AddFoto(int idFoto, int idKegiatan);
        Task<Kegiatan> RemoveFoto(int idFoto, int idKegiatan);
    }
}
