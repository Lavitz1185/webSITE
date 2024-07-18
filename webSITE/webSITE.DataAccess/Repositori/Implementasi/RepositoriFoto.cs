using Microsoft.EntityFrameworkCore;
using webSITE.Domain;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain.Exceptions;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriFoto : IRepositoriFoto
    {
        private readonly AppDbContext _dbContext;

        public RepositoriFoto(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Foto?> Get(int id)
        {
            var foto = await _dbContext.TblFoto
                .FirstOrDefaultAsync(f => f.Id == id);

            return foto;
        }

        public async Task<Foto?> GetWithMahasiswa(int id)
        {
            var foto = await _dbContext.TblFoto
                .Include(f => f.DaftarMahasiswa)
                .FirstOrDefaultAsync(f => f.Id == id);

            return foto;
        }

        public async Task<Foto?> GetWithKegiatan(int id)
        {
            var listFoto = await _dbContext.TblFoto
                .Include(f => f.DaftarKegiatan)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();

            return listFoto;
        }

        public async Task<List<Foto>?> GetAll()
        {
            var listFoto = await _dbContext.TblFoto
                .ToListAsync();

            return listFoto;
        }

        public async Task<List<Foto>?> GetAllWithMahasiswa()
        {
            var listFoto = await _dbContext.TblFoto
                .Include(f => f.DaftarMahasiswa)
                .ToListAsync();

            return listFoto;
        }

        public async Task<List<Foto>?> GetAllWithKegiatan()
        {
            var listFoto = await _dbContext.TblFoto
                .Include(f => f.DaftarKegiatan)
                .ToListAsync();

            return listFoto;
        }

        public async Task<List<Foto>?> GetAllByTanggal(DateTime tanggal)
        {
            var listFoto = await _dbContext.TblFoto
                .Where(f => f.AddedAt == tanggal)
                .OrderBy(f => f.AddedAt)
                .ToListAsync();

            return listFoto;
        }

        public void Add(Foto foto)
        {
            _dbContext.TblFoto.Add(foto);
        }

        public async Task Delete(int id)
        {
            var foto = await _dbContext.TblFoto.FindAsync(id);

            if (foto == null) throw new FotoNotFoundException(id);

            _dbContext.TblFoto.Remove(foto);
        }

        public void Update(Foto foto)
        {
            _dbContext.Update(foto);
        }
    }
}
