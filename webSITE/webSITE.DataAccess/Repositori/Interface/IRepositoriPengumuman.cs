using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain;

namespace webSITE.DataAccess.Repositori.Interface
{
    public interface IRepositoriPengumuman
    {
        Task<Pengumuman?> Get(int id);
        Task<Pengumuman?> GetPriority();
        Task<List<Pengumuman>?> GetAll();

        void Add(Pengumuman pengumuman);
        Task Delete(int id);
        void Update(Pengumuman pengumuman);
    }
}
