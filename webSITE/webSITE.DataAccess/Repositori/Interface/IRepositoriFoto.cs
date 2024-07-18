using webSITE.Domain;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriFoto
    {
        Task<Foto?> Get(int id);
        Task<Foto?> GetWithMahasiswa(int id);
        Task<Foto?> GetWithKegiatan(int id);
        Task<List<Foto>?> GetAll();
        Task<List<Foto>?> GetAllWithMahasiswa();
        Task<List<Foto>?> GetAllWithKegiatan();
        Task<List<Foto>?> GetAllByTanggal(DateTime tanggal);

        void Add(Foto foto);
        Task Delete(int id);
        void Update(Foto foto);
    }
}
