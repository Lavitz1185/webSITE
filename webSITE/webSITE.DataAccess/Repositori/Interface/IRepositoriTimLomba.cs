using webSITE.Domain;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriTimLomba
    {
        void Add(TimLomba timLomba);
        Task Delete(int id);
    }
}
