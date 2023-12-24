using Microsoft.EntityFrameworkCore;
using webSITE.Models;
using webSITE.Repositori.Data;
using webSITE.Repositori.Interface;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriFoto : IRepositoriFoto
    {
        private readonly AppDbContext _dbContext;

        public RepositoriFoto(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Foto> Create(Foto entity)
        {
            var entityDb = await Get(entity.Id);
            if(entityDb == null)
            {
                _dbContext.TblFoto.Add(entity);
                await _dbContext.SaveChangesAsync();
                entityDb = entity;
            }
            return entityDb;
        }

        public async Task<Foto> Delete(int id)
        {
            var foto = await _dbContext.TblFoto.FindAsync(id);
            if(foto == null)
            {
                _dbContext.TblFoto.Remove(foto);
                await _dbContext.SaveChangesAsync();
            }    

            return foto;
        }

        public async Task<Foto> Get(int id)
        {
            var foto = await _dbContext.TblFoto
                .Include(f => f.DaftarMahasiswa)
                .Include(f => f.Kegiatan)
                .FirstOrDefaultAsync( f => f.Id == id);
            return foto;
        }

        public async Task<IEnumerable<Foto>> GetAll()
        {
            var listFoto = await _dbContext.TblFoto
                .Include(f => f.Kegiatan)
                .ToListAsync();
            return listFoto;
        }

        public async Task<IEnumerable<Foto>> GetAllByKegiatan(int kegiatanId)
        {
            var listFoto = await _dbContext.TblFoto.Where(f => f.IdKegiatan == kegiatanId)
                .Include(f => f.Kegiatan).ToListAsync();
            return listFoto;
        }

        public async Task<IEnumerable<Foto>> GetAllByTanggal(DateTime tanggal)
        {
            var listFoto = await _dbContext.TblFoto
                .Where(f => f.Tanggal == tanggal).OrderBy(f => f.Tanggal)
                .ToListAsync();

            return listFoto;
        }

        public async Task<Foto> Update(Foto entity)
        {
            var entityDb = await _dbContext.TblFoto.FindAsync(entity.Id);
            if (entityDb != null)
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            else
                return entityDb;
        }
    }
}
