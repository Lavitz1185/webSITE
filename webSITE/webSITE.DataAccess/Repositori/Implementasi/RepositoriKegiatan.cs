using Microsoft.EntityFrameworkCore;
using webSITE.Domain;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain.Exceptions;
using webSITE.Domain.Exceptions.KegiatanExceptions;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriKegiatan : IRepositoriKegiatan
    {
        private readonly AppDbContext _dbContext;

        public RepositoriKegiatan(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Kegiatan?> Get(int id)
        {
            var kegiatan = await _dbContext.TblKegiatan
                .FirstOrDefaultAsync(k => k.Id == id);

            return kegiatan;
        }

        public async Task<Kegiatan?> GetWithDetail(int id)
        {
            var kegiatan = await _dbContext.TblKegiatan
                .Include(k => k.DaftarFoto)
                .Include(k => k.DaftarMahasiswa)
                .FirstOrDefaultAsync(k => k.Id == id);

            return kegiatan;
        }

        public async Task<List<Kegiatan>?> GetAll()
        {
            var daftarKegiatan = await _dbContext.TblKegiatan
                .ToListAsync();

            return daftarKegiatan;
        }

        public async Task<List<Kegiatan>?> GetAllWithDetail()
        {
            var daftarKegiatan = await _dbContext.TblKegiatan
                .Include(k => k.DaftarFoto)
                .Include(k => k.DaftarMahasiswa)
                .ToListAsync();

            return daftarKegiatan;
        }

        public async Task<List<Kegiatan>?> GetAllByNamaKegiatan(string namaKegiatan)
        {
            var kegiatan = await _dbContext.TblKegiatan
                .Where(k => k.NamaKegiatan.ToLower() == namaKegiatan.ToLower())
                .ToListAsync();

            return kegiatan;
        }

        public async Task<bool> IsDuplicateName(int id, string nama, DateTime tanggal)
        {
            return await _dbContext.TblKegiatan
                .AnyAsync(k => k.Id != id && k.NamaKegiatan == nama && k.Tanggal.Date == tanggal.Date);
        }

        public void Add(Kegiatan entity)
        {
            _dbContext.TblKegiatan.Add(entity);
        }

        public async Task Delete(int id)
        {
            var entityDb = await _dbContext.TblKegiatan
                .Where(k => k.Id == id).FirstOrDefaultAsync();

            if (entityDb is null) throw new KegiatanNotFoundException(id);

            _dbContext.TblKegiatan.Remove(entityDb);
        }

        public void Update(Kegiatan entity)
        {
            _dbContext.TblKegiatan.Update(entity);
        }
    }
}
