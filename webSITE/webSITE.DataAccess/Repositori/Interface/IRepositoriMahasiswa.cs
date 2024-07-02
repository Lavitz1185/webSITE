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

        Task Add(Mahasiswa entity);
        Task Update(Mahasiswa entity);
        Task Delete(string id);
        Task SetProfilePicture(string id, byte[] photoData);
        Task AddToFoto(string idMahasiswa, int idFoto);
        Task RemoveFromFoto(string idMahasiswa, int idFoto);
        Task AddToKegiatan(string idMahasiswa, int idKegiatan);
        Task RemoveFromKegiatan(string idMahasiswa, int idKegiatan);
    }
}
    