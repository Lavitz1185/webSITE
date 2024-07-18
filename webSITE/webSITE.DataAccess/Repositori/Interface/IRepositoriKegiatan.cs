using webSITE.Domain;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriKegiatan
    {
        Task<Kegiatan?> Get(int id);
        Task<Kegiatan?> GetWithDetail(int id);
        Task<List<Kegiatan>?> GetAll();
        Task<List<Kegiatan>?> GetAllWithDetail();
        Task<List<Kegiatan>?> GetAllByNamaKegiatan(string namaKegiatan);
        Task<bool> IsDuplicateName(int id, string nama, DateTime tanggal);

        void Add(Kegiatan kegiatan);
        void Update(Kegiatan kegiatan);
        Task Delete(int id);
    }
}
