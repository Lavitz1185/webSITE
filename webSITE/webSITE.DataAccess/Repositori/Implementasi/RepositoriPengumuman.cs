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

        public Task Add(Pengumuman entity)
        {
            _appDbContext.Add(entity);
            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            var pengumuman = await _appDbContext.TblPengumuman
                .Where(p => p.Id == id).FirstOrDefaultAsync();

            if (pengumuman is null)
                throw new PengumumanNotFoundException(id);

            if (pengumuman.IsPriority)
                throw new PengumumanDeletingPriority();

            _appDbContext.TblPengumuman.Remove(pengumuman);
        }

        public async Task<Pengumuman?> Get(int id)
        {
            return await _appDbContext.TblPengumuman
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pengumuman?> GetPriority()
        {
            return await _appDbContext.TblPengumuman
                .Where(p => p.IsPriority)
                .AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<Pengumuman>?> GetAll()
        {
            return await _appDbContext.TblPengumuman
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<Pengumuman>?> GetAllWithDetail()
        {
            return await _appDbContext.TblPengumuman
                .AsNoTracking().ToListAsync();
        }

        public async Task<Pengumuman?> GetWithDetail(int id)
        {
            return await _appDbContext.TblPengumuman
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Pengumuman entity)
        {
            var pengumuman = await _appDbContext.TblPengumuman
                .Where(p => p.Id == entity.Id).FirstOrDefaultAsync();

            if (pengumuman is null)
                throw new PengumumanNotFoundException(entity.Id);

            _appDbContext.TblPengumuman.Update(pengumuman);

            pengumuman.Judul = entity.Judul;
            pengumuman.Id = entity.Id;
            pengumuman.Tanggal = entity.Tanggal;
            pengumuman.IsPriority = entity.IsPriority;
        }
    }
}
