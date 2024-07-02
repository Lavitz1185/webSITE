using webSITE.Domain;
using webSITE.DataAccess.Repositori.Commons;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriFoto : IBaseRepositori<Foto>
    {
        Task<IEnumerable<Foto>?> GetAllByKegiatan(int kegiatanId);
        Task<IEnumerable<Foto>?> GetAllByTanggal(DateTime tanggal);
        Task AddMahasiswa(string idMahasiswa, int idFoto);
        Task RemoveMahasiswa(string idMahasiswa, int idFoto);
    }
}
