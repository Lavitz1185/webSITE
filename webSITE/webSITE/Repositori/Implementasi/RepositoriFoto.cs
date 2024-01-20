using Microsoft.EntityFrameworkCore;
using webSITE.Domain;
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

        public async Task<Foto> AddMahasiswa(string idMahasiswa, int idFoto)
        {
            var mahasiswa = await _dbContext.TblMahasiswa
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == idMahasiswa);

            var foto = await Get(idFoto);
            var mahasiswaFoto = await _dbContext.TblMahasiswaFoto.FindAsync(idFoto, idMahasiswa);

            if (mahasiswa == null || foto == null || mahasiswaFoto != null)
                return null;

            var newMahasiswaFoto = new MahasiswaFoto
            {
                IdFoto = idFoto,
                IdMahasiswa = idMahasiswa
            };

            _dbContext.TblMahasiswaFoto.Add(newMahasiswaFoto);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 0)
                return null;

            return await GetWithDetail(idFoto);
        }

        public async Task<Foto> Create(Foto entity)
        {
            var tracker = _dbContext.TblFoto.Add(entity);
            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
                return null;

            return await Get(tracker.Entity.Id);
        }

        public async Task<Foto> Delete(int id)
        {
            var foto = await _dbContext.TblFoto.FindAsync(id);

            if (foto == null) return null;

            _dbContext.TblFoto.Remove(foto);
            await _dbContext.SaveChangesAsync();

            return foto;
        }

        public async Task<Foto> Get(int id)
        {
            var foto = await _dbContext.TblFoto
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
            return foto;
        }

        public async Task<IEnumerable<Foto>> GetAll()
        {
            var listFoto = await _dbContext.TblFoto
                .AsNoTracking()
                .ToListAsync();

            return listFoto;
        }

        public async Task<IEnumerable<Foto>> GetAllByKegiatan(int kegiatanId)
        {
            var listFoto = await _dbContext.TblFoto.Where(f => f.IdKegiatan == kegiatanId)
                .Include(f => f.Kegiatan)
                .AsNoTracking()
                .ToListAsync();
            return listFoto;
        }

        public async Task<IEnumerable<Foto>> GetAllByTanggal(DateTime tanggal)
        {
            var listFoto = await _dbContext.TblFoto
                .Where(f => f.Tanggal == tanggal)
                .OrderBy(f => f.Tanggal)
                .AsNoTracking()
                .ToListAsync();

            return listFoto;
        }

        public async Task<IEnumerable<Foto>> GetAllWithDetail()
        {
            var listFoto = await _dbContext.TblFoto
                .Include(f => f.DaftarMahasiswa)
                .Include(f => f.Kegiatan)
                .AsNoTracking()
                .ToListAsync();

            return listFoto;
        }

        public async Task<Foto> GetWithDetail(int id)
        {
            var foto = await _dbContext.TblFoto
                .Include(f => f.DaftarMahasiswa)
                .Include(f => f.Kegiatan)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);

            return foto;
        }

        public async Task<Foto> RemoveMahasiswa(string idMahasiswa, int idFoto)
        {
            var mahasiswaFoto = await _dbContext.TblMahasiswaFoto.FindAsync(idFoto, idMahasiswa);

            if (mahasiswaFoto == null) return null;

            _dbContext.TblMahasiswaFoto.Remove(mahasiswaFoto);
            await _dbContext.SaveChangesAsync();

            return await Get(idFoto);
        }

        public async Task<Foto> Update(Foto entity)
        {
            var entityDb = await _dbContext.TblFoto.FindAsync(entity.Id);

            if (entityDb == null)
                return null;

            _dbContext.Update(entityDb);

            entityDb.Tanggal = entity.Tanggal;
            entityDb.IdKegiatan = entity.IdKegiatan;
            entityDb.PhotoPath = entity.PhotoPath;

            var result = await _dbContext.SaveChangesAsync();
            if (result == 0) return null;

            return await Get(entityDb.Id);
        }
    }
}
