using webSITE.Domain;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriLomba
    {
        Task<Lomba?> Get(int id);
        Task<Lomba?> GetWithDetail(int id);
        Task<List<Lomba>?> GetAll();
        Task<List<Lomba>?> GetAllWithDetail();
        Task<bool> IsNameUnique(string name);

        void Add(Lomba lomba);
        void Update(Lomba lomba);
        Task Delete(int id);
    }
}
