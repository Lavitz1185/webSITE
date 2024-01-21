using webSITE.Domain;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriMahasiswaFoto
    {
        Task<MahasiswaFoto> Create(string idMahasiswa, int idFoto);
        Task<MahasiswaFoto> Delete(string idMahasiswa, int idFoto);
    }
}
