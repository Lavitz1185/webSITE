using Microsoft.EntityFrameworkCore;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Domain.Exceptions.TimLombaExceptions;

namespace webSITE.DataAccess.Repositori.Implementasi
{
    public class RepositoriTimLomba : IRepositoriTimLomba
    {
        private readonly AppDbContext _appDbContext;

        public RepositoriTimLomba(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(TimLomba timLomba)
        {
            _appDbContext.TblTimLomba.Add(timLomba);
        }

        public async Task Delete(int id)
        {
            var timLomba = await _appDbContext.TblTimLomba
                .FirstOrDefaultAsync(t => t.Id == id);

            if (timLomba is null) throw new TimLombaNotFoundException($"Tim Lomba dengan ID : {id} tidak ditemukan");

            _appDbContext.TblTimLomba.Remove(timLomba);
        }
    }
}
