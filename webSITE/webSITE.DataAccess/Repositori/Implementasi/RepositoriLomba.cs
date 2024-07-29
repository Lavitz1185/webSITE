using Microsoft.EntityFrameworkCore;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Domain.Exceptions.LombaExceptions;

namespace webSITE.DataAccess.Repositori.Implementasi
{
    public class RepositoriLomba : IRepositoriLomba
    {
        private readonly AppDbContext _appDbContext;

        public RepositoriLomba(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Lomba?> Get(int id)
        {
            return await _appDbContext.TblLomba
                .Include(l => l.FotoLomba)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Lomba?> GetWithDetail(int id)
        {
            return await _appDbContext.TblLomba
                .Include(l => l.FotoLomba)
                .Include(l => l.DaftarPeserta)
                .Include(l => l.DaftarTim).ThenInclude(t => t.AnggotaTim)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Lomba>?> GetAll()
        {
            return await _appDbContext.TblLomba
                .Include(l => l.FotoLomba)
                .ToListAsync();
        }

        public async Task<List<Lomba>?> GetAllWithDetail()
        {
            return await _appDbContext.TblLomba
                .Include(l => l.FotoLomba)
                .Include(l => l.DaftarPeserta)
                .Include(l => l.DaftarTim)
                .ToListAsync();
        }

        public async Task<bool> IsNameUnique(string name)
        {
            return await _appDbContext
                .TblLomba.AnyAsync(l => l.Nama.Trim().ToUpper() == name.Trim().ToUpper());
        }

        public void Add(Lomba lomba)
        {
            _appDbContext.Add(lomba);
        }

        public async Task Delete(int id)
        {
            var lomba = await _appDbContext.TblLomba
                .FirstOrDefaultAsync(l => l.Id == id);

            if (lomba is null)
                throw new LombaNotFoundException($"Lomba dengan ID : {id} tidak ditemukan");

            _appDbContext.TblLomba.Remove(lomba);
        }

        public void Update(Lomba lomba)
        {
            _appDbContext.TblLomba.Update(lomba);
        }
    }
}
