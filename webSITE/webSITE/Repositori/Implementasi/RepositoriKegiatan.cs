using Microsoft.EntityFrameworkCore;
using webSITE.Models;
using webSITE.Repositori.Data;
using webSITE.Repositori.Interface;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriKegiatan : IRepositoriKegiatan
    {
        private readonly AppDbContext _dbContext;

        public RepositoriKegiatan(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Kegiatan> Create(Kegiatan entity)
        {
            var entityDb = await _dbContext.TblKegiatan.FindAsync(entity.Id);
            if(entityDb == null)
            {
                _dbContext.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            return entityDb;
        }

        public async Task<Kegiatan> Delete(int id)
        {
            var entityDb = await _dbContext.TblKegiatan.FindAsync(id);
            if (entityDb != null)
            {
                _dbContext.Remove(entityDb);
                await _dbContext.SaveChangesAsync();
            }
            return entityDb;
        }

        public async Task<Kegiatan> Get(int id)
        {
            var kegiatan = await _dbContext.TblKegiatan
                .Include(k => k.DaftarFoto)
                .Include(k => k.DaftarMahasiswa)
                .FirstOrDefaultAsync(k => k.Id == id);

            return kegiatan;
        }

        public async Task<IEnumerable<Kegiatan>> GetAll()
        {
            var kegiatan = await _dbContext.TblKegiatan.ToListAsync();

            return kegiatan;
        }

        public async Task<Kegiatan> Update(Kegiatan entity)
        {
            var entityDb = await _dbContext.TblKegiatan.FindAsync(entity.Id);
            if(entityDb != null)
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }

            return entityDb;
        }
    }
}
