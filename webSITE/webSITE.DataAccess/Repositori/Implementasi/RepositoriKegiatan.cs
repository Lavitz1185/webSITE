using Microsoft.EntityFrameworkCore;
using webSITE.Domain;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain.Exceptions;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriKegiatan : IRepositoriKegiatan
    {
        private readonly AppDbContext _dbContext;

        public RepositoriKegiatan(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddFoto(int idFoto, int idKegiatan)
        {
            var foto = await _dbContext.TblFoto
                .FirstOrDefaultAsync(f => f.Id == idFoto);

            var kegiatan = await _dbContext.TblKegiatan
                .Include(k => k.DaftarFoto)
                .FirstOrDefaultAsync(k => k.Id == idKegiatan);

            if (foto is null) throw new FotoNotFoundException(idFoto);

            if (kegiatan is null) throw new KegiatanNotFoundException(idKegiatan);

            if (kegiatan.DaftarFoto.FirstOrDefault(f => f.Id == idFoto) is not null)
                throw new KegiatanAlreadyHaveFotoException(idFoto);

            _dbContext.TblKegiatan.Update(kegiatan);

            kegiatan.DaftarFoto.Add(foto);
        }

        public async Task AddMahasiswa(string idMahasiswa, int idKegiatan)
        {
            var mahasiswa = await _dbContext.TblMahasiswa
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == idMahasiswa);

            var kegiatan = await Get(idKegiatan);

            var pesertaKegiatan = await _dbContext.TblPesertaKegiatan
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdMahasiswa == idMahasiswa && x.IdKegiatan == idKegiatan);

            if (mahasiswa is null) throw new MahasiswaNotFoundException(idMahasiswa);

            if (kegiatan is null) throw new KegiatanNotFoundException(idKegiatan);

            if (pesertaKegiatan is not null)
                throw new PesertaKegiatanAlreadyExistsException(idKegiatan, idMahasiswa);

            pesertaKegiatan = new PesertaKegiatan
            {
                IdMahasiswa = idMahasiswa,
                IdKegiatan = idKegiatan
            };

            _dbContext.TblPesertaKegiatan.Add(pesertaKegiatan);
        }

        public async Task Add(Kegiatan entity)
        {
            var kegiatan = await _dbContext.TblKegiatan
                .Where(k => k.NamaKegiatan == entity.NamaKegiatan && k.Tanggal == entity.Tanggal)
                .FirstOrDefaultAsync();

            if (kegiatan is not null)
                throw new KegiatanAlreadyExistsException(entity.NamaKegiatan, entity.Tanggal);

            _dbContext.TblKegiatan.Add(entity);
        }

        public async Task Delete(int id)
        {
            var entityDb = await GetWithDetail(id);

            if (entityDb == null) throw new KegiatanNotFoundException(id);

            _dbContext.TblKegiatan.Remove(entityDb);
        }

        public async Task<Kegiatan?> Get(int id)
        {
            var kegiatan = await _dbContext.TblKegiatan
                .AsNoTracking()
                .FirstOrDefaultAsync(k => k.Id == id);

            return kegiatan;
        }

        public async Task<List<Kegiatan>?> GetAll()
        {
            var daftarKegiatan = await _dbContext.TblKegiatan
                .AsNoTracking()
                .ToListAsync();

            return daftarKegiatan;
        }

        public async Task<List<Kegiatan>?> GetAllWithDetail()
        {
            var daftarKegiatan = await _dbContext.TblKegiatan
                .Include(k => k.DaftarFoto)
                .Include(k => k.DaftarMahasiswa)
                .AsNoTracking()
                .ToListAsync();

            return daftarKegiatan;
        }

        public async Task<List<Kegiatan>?> GetAllByNamaKegiatan(string namaKegiatan)
        {
            var kegiatan = await _dbContext.TblKegiatan
                .Where(k => k.NamaKegiatan.ToLower() == namaKegiatan.ToLower())
                .AsNoTracking()
                .ToListAsync();

            return kegiatan;
        }

        public async Task<Kegiatan?> GetWithDetail(int id)
        {
            var kegiatan = await _dbContext.TblKegiatan
                .Include(k => k.DaftarFoto)
                .Include(k => k.DaftarMahasiswa)
                .AsNoTracking()
                .FirstOrDefaultAsync(k => k.Id == id);

            return kegiatan;
        }

        public async Task RemoveFoto(int idFoto, int idKegiatan)
        {
            var foto = await _dbContext.TblFoto
                .FirstOrDefaultAsync(f => f.Id == idFoto);

            var kegiatan = await _dbContext.TblKegiatan
                .Include(k => k.DaftarFoto)
                .FirstOrDefaultAsync(m => m.Id == idKegiatan);

            if (foto is null) throw new FotoNotFoundException(idFoto);

            if (kegiatan is null) throw new KegiatanNotFoundException(idKegiatan);

            if (kegiatan.DaftarFoto.FirstOrDefault(f => f.Id == idFoto) is null)
                throw new KegiatanDontHaveFotoException(idKegiatan, idFoto);

            _dbContext.TblKegiatan.Update(kegiatan);
            kegiatan.DaftarFoto.Remove(foto);
        }

        public async Task RemoveMahasiswa(string idMahasiswa, int idKegiatan)
        {
            var mahasiswa = await _dbContext.TblMahasiswa
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == idMahasiswa);

            var kegiatan = await Get(idKegiatan);

            var pesertaKegiatan = await _dbContext.TblPesertaKegiatan
                .FirstOrDefaultAsync(x => x.IdMahasiswa == idMahasiswa && x.IdKegiatan == idKegiatan);

            if (mahasiswa is null) throw new MahasiswaFotoNotFoundException(idMahasiswa);

            if (kegiatan is null) throw new KegiatanNotFoundException(idKegiatan);

            if (pesertaKegiatan is null) throw new PesertaKegiatanNotFoundException(idKegiatan, idMahasiswa);

            _dbContext.TblPesertaKegiatan.Remove(pesertaKegiatan);
        }

        public async Task Update(Kegiatan entity)
        {
            var entityDb = await Get(entity.Id);

            if (entityDb == null) throw new KegiatanNotFoundException(entity.Id);

            var kegiatan = await _dbContext.TblKegiatan
                .Where(k => k.NamaKegiatan == entity.NamaKegiatan && k.Tanggal == entity.Tanggal)
                .FirstOrDefaultAsync();

            if (kegiatan is not null)
                throw new KegiatanAlreadyExistsException(entity.NamaKegiatan, entity.Tanggal);

            _dbContext.TblKegiatan.Update(entityDb);

            entityDb.NamaKegiatan = entity.NamaKegiatan;
            entityDb.Tanggal = entity.Tanggal;
            entityDb.JumlahHari = entity.JumlahHari;
            entityDb.TempatKegiatan = entity.TempatKegiatan;
            entityDb.Keterangan = entity.Keterangan;
        }
    }
}
