using webSITE.Domain;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriMahasiswa
    {
        Task<Mahasiswa?> Get(string id);
        Task<Mahasiswa?> GetWithDetail(string id);
        Task<List<Mahasiswa>?> GetAll();
        Task<List<Mahasiswa>?> GetAllWithDetail();
        Task<Mahasiswa?> GetByNim(string nim);

        void Add(Mahasiswa entity);
        void Update(Mahasiswa entity);
        Task Delete(string id);
    }
}
    