using Microsoft.EntityFrameworkCore;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Domain.Exceptions;

namespace webSITE.DataAccess.Repositori.Implementasi
{
    public class RepositoriPengumuman : IRepositoriPengumuman
    {
        private readonly AppDbContext _appDbContext;

        public RepositoriPengumuman(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Pengumuman?> Get(int id)
        {
            return await _appDbContext.TblPengumuman
                .Include(p => p.Foto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pengumuman?> GetPriority()
        {
            return await _appDbContext.TblPengumuman
                .Where(p => p.IsPriority)
                .Include(p => p.Foto)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Pengumuman>?> GetAll()
        {
            return await _appDbContext.TblPengumuman
                .Include(p => p.Foto).ToListAsync();
        }

        public void Add(Pengumuman entity)
        {
            _appDbContext.Add(entity);
        }

        public async Task Delete(int id)
        {
            var pengumuman = await _appDbContext.TblPengumuman
                .Where(p => p.Id == id).FirstOrDefaultAsync();

            if (pengumuman is null)
                throw new PengumumanNotFoundException(id);

            if (pengumuman.IsPriority)
                throw new PengumumanDeletingPriorityException();

            _appDbContext.TblPengumuman.Remove(pengumuman);
        }

        public void Update(Pengumuman entity)
        {
            _appDbContext.TblPengumuman.Update(entity);
        }
    }
}
