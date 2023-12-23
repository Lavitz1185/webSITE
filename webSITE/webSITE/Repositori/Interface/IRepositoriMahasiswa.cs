using webSITE.Models;
using webSITE.Repositori.Commons;

namespace webSITE.Repositori.Interface
{
    public interface IRepositoriMahasiswa : IBaseRepositori<Mahasiswa>
    {
        Task<Mahasiswa> GetByNim(string nim);
    }
}
