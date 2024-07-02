using webSITE.Domain;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriMahasiswaFoto
    {
        Task Add(string idMahasiswa, int idFoto);
        Task Delete(string idMahasiswa, int idFoto);
    }
}
