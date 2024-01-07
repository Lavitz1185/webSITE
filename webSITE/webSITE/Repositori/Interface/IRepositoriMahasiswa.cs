using webSITE.Models;
using webSITE.Repositori.Commons;

namespace webSITE.Repositori.Interface
{
    public interface IRepositoriMahasiswa
    {
        Task<Mahasiswa> Get(string id);
        Task<IEnumerable<Mahasiswa>> GetAll();
        Task<Mahasiswa> Create(Mahasiswa entity);
        Task<Mahasiswa> Update(Mahasiswa entity);
        Task<Mahasiswa> Delete(string id);
        Task<Mahasiswa> GetByNim(string nim);
    }
}
