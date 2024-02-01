using Microsoft.EntityFrameworkCore;
using webSITE.Domain;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriKegiatan : IRepositoriKegiatan
    {
        private readonly AppDbContext _dbContext;

        public RepositoriKegiatan(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Kegiatan> AddFoto(int idFoto, int idKegiatan)
        {
            var foto = await _dbContext.TblFoto.AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == idFoto);
            var kegiatan = await GetWithDetail(idKegiatan);

            if (foto is null || kegiatan is null || kegiatan.DaftarFoto.Contains(foto))
                return null;

            _dbContext.TblKegiatan.Update(kegiatan);
            kegiatan.DaftarFoto.Add(foto);

            await _dbContext.SaveChangesAsync();

            return await Get(idKegiatan);
        }

        public async Task<Kegiatan> AddMahasiswa(string idMahasiswa, int idKegiatan)
        {
            var mahasiswa = await _dbContext.TblMahasiswa
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == idMahasiswa);
            var kegiatan = await Get(idKegiatan);
            var pesertaKegiatan = await _dbContext.TblPesertaKegiatan
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdMahasiswa == idMahasiswa && x.IdKegiatan == idKegiatan);

            if (mahasiswa is null || kegiatan is null || pesertaKegiatan is not null)
                return null;

            pesertaKegiatan = new PesertaKegiatan
            {
                IdMahasiswa = idMahasiswa,
                IdKegiatan = idKegiatan
            };

            _dbContext.TblPesertaKegiatan.Add(pesertaKegiatan);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 0)
                return null;

            return await Get(idKegiatan);
        }

        public async Task<Kegiatan> Create(Kegiatan entity)
        {
            var tracker = _dbContext.TblKegiatan.Add(entity);
            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
                return null;

            return await Get(tracker.Entity.Id);
        }

        public async Task<Kegiatan> Delete(int id)
        {
            var entityDb = await GetWithDetail(id);
            if (entityDb == null)
                return null;

            _dbContext.TblKegiatan.Remove(entityDb);
            await _dbContext.SaveChangesAsync();
            return entityDb;
        }

        public async Task<Kegiatan> Get(int id)
        {
            var kegiatan = await _dbContext.TblKegiatan
                .AsNoTracking()
                .FirstOrDefaultAsync(k => k.Id == id);

            return kegiatan;
        }

        public async Task<IEnumerable<Kegiatan>> GetAll()
        {
            var daftarKegiatan = await _dbContext.TblKegiatan
                .AsNoTracking()
                .ToListAsync();

            return daftarKegiatan;
        }

        public async Task<IEnumerable<Kegiatan>> GetAllWithDetail()
        {
            var daftarKegiatan = await _dbContext.TblKegiatan
                .Include(k => k.DaftarFoto)
                .Include(k => k.DaftarMahasiswa)
                .AsNoTracking()
                .ToListAsync();

            return daftarKegiatan;
        }

        public async Task<Kegiatan> GetKegiatanByNamaKegiatan(string namaKegiatan)
        {
            var kegiatan = await _dbContext.TblKegiatan
                .AsNoTracking()
                .FirstOrDefaultAsync(k => k.NamaKegiatan.ToLower() == namaKegiatan.ToLower());

            return kegiatan;
        }

        public async Task<Kegiatan> GetWithDetail(int id)
        {
            var kegiatan = await _dbContext.TblKegiatan
                .Include(k => k.DaftarFoto).ThenInclude(f => f.DaftarMahasiswa)
                .Include(k => k.DaftarMahasiswa)
                .AsNoTracking()
                .FirstOrDefaultAsync(k => k.Id == id);

            return kegiatan;
        }

        public async Task<Kegiatan> RemoveFoto(int idFoto, int idKegiatan)
        {
            var foto = await _dbContext.TblFoto.AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == idFoto);
            var kegiatan = await GetWithDetail(idKegiatan);

            if (foto is null || kegiatan is null || kegiatan.DaftarFoto.Contains(foto))
                return null;

            _dbContext.TblKegiatan.Update(kegiatan);
            kegiatan.DaftarFoto.Remove(foto);

            await _dbContext.SaveChangesAsync();

            return await Get(idKegiatan);
        }

        public async Task<Kegiatan> RemoveMahasiswa(string idMahasiswa, int idKegiatan)
        {
            var mahasiswa = await _dbContext.TblMahasiswa
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == idMahasiswa);
            var kegiatan = await Get(idKegiatan);
            var pesertaKegiatan = await _dbContext.TblPesertaKegiatan
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdMahasiswa == idMahasiswa && x.IdKegiatan == idKegiatan);

            if (mahasiswa is null || kegiatan is null || pesertaKegiatan is null)
                return null;

            _dbContext.TblPesertaKegiatan.Remove(pesertaKegiatan);
            await _dbContext.SaveChangesAsync();

            return await Get(idKegiatan);
        }

        public async Task<Kegiatan> Update(Kegiatan entity)
        {
            var entityDb = await Get(entity.Id);
            if (entityDb == null)
                return null;

            _dbContext.TblKegiatan.Update(entityDb);

            entityDb.NamaKegiatan = entity.NamaKegiatan;
            entityDb.Tanggal = entity.Tanggal;
            entityDb.JumlahHari = entity.JumlahHari;
            entityDb.TempatKegiatan = entity.TempatKegiatan;
            entityDb.Keterangan = entity.Keterangan;

            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
                return null;

            return await Get(entity.Id);
        }
    }
}
