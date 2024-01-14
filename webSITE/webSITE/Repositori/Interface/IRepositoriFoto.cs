using webSITE.Domain;
using webSITE.Repositori.Commons;

namespace webSITE.Repositori.Interface
{
    public interface IRepositoriFoto : IBaseRepositori<Foto>
    {
        Task<IEnumerable<Foto>> GetAllByKegiatan(int kegiatanId);
        Task<IEnumerable<Foto>> GetAllByTanggal(DateTime tanggal);
    }
}
