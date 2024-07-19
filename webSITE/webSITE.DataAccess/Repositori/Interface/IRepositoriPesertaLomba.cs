using webSITE.Domain;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriPesertaLomba
    {
        void Add(PesertaLomba pesertaLomba);
        Task Delete(int id);
    }
}
