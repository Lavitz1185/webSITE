using webSITE.Models;
using webSITE.Repositori.Commons;

namespace webSITE.Repositori.Interface
{
    public interface IRepositoriMahasiswa
    {
        Task<Mahasiswa> Get(string id);
        Task<Mahasiswa> GetWithDetail(string id);
        Task<IEnumerable<Mahasiswa>> GetAll();
        Task<IEnumerable<Mahasiswa>> GetAllWithDetail();
        Task<Mahasiswa> GetByNim(string nim);
        Task<Mahasiswa> Create(Mahasiswa entity);
        Task<Mahasiswa> Update(Mahasiswa entity);
        Task<Mahasiswa> Delete(string id);
        Task<Mahasiswa> SetProfilePicture(string id, byte[] photoData);
        Task<Mahasiswa> AddToFoto(string idMahasiswa, int idFoto);
        Task<Mahasiswa> RemoveFromFoto(string idMahasiswa, int idFoto);
        Task<Mahasiswa> AddToKegiatan(string idMahasiswa, int idKegiatan);
        Task<Mahasiswa> RemoveFromKegiatan(string idMahasiswa, int idKegiatan);
    }
}
    