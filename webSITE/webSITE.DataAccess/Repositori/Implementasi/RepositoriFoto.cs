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

        public async Task AddMahasiswa(string idMahasiswa, int idFoto)
        {
            var mahasiswa = await _dbContext.TblMahasiswa
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == idMahasiswa);

            var foto = await Get(idFoto);
            var mahasiswaFoto = await _dbContext.TblMahasiswaFoto.FindAsync(idFoto, idMahasiswa);

            if (mahasiswa == null)
                throw new MahasiswaNotFoundException(idMahasiswa);

            if(foto == null)
                throw new FotoNotFoundException(idFoto);

            if (mahasiswaFoto != null)
                throw new MahasiswaFotoAlreadyExistsException(idFoto, idMahasiswa);

            var newMahasiswaFoto = new MahasiswaFoto
            {
                IdFoto = idFoto,
                IdMahasiswa = idMahasiswa
            };

            _dbContext.TblMahasiswaFoto.Add(newMahasiswaFoto); 
        }

        public Task Add(Foto entity)
        {
            _dbContext.TblFoto.Add(entity);

            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            var foto = await _dbContext.TblFoto.FindAsync(id);

            if (foto == null) throw new FotoNotFoundException(id);

            _dbContext.TblFoto.Remove(foto);
        }

        public async Task<Foto?> Get(int id)
        {
            var foto = await _dbContext.TblFoto
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);

            return foto;
        }

        public async Task<List<Foto>?> GetAll()
        {
            var listFoto = await _dbContext.TblFoto
                .AsNoTracking()
                .ToListAsync();

            return listFoto;
        }

        public async Task<IEnumerable<Foto>?> GetAllByKegiatan(int kegiatanId)
        {
            var listFoto = await _dbContext.TblFoto.Where(f => f.IdKegiatan == kegiatanId)
                .Include(f => f.Kegiatan)
                .AsNoTracking()
                .ToListAsync();
            return listFoto;
        }

        public async Task<IEnumerable<Foto>?> GetAllByTanggal(DateTime tanggal)
        {
            var listFoto = await _dbContext.TblFoto
                .Where(f => f.Tanggal == tanggal)
                .OrderBy(f => f.Tanggal)
                .AsNoTracking()
                .ToListAsync();

            return listFoto;
        }

        public async Task<List<Foto>?> GetAllWithDetail()
        {
            var listFoto = await _dbContext.TblFoto
                .Include(f => f.DaftarMahasiswa)
                .Include(f => f.Kegiatan)
                .AsNoTracking()
                .ToListAsync();

            return listFoto;
        }

        public async Task<Foto?> GetWithDetail(int id)
        {
            var foto = await _dbContext.TblFoto
                .Include(f => f.DaftarMahasiswa)
                .Include(f => f.Kegiatan)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);

            return foto;
        }

        public async Task RemoveMahasiswa(string idMahasiswa, int idFoto)
        {
            var mahasiswaFoto = await _dbContext.TblMahasiswaFoto.FindAsync(idFoto, idMahasiswa);

            if (mahasiswaFoto == null) throw new MahasiswaFotoNotFoundException(idFoto, idMahasiswa);

            _dbContext.TblMahasiswaFoto.Remove(mahasiswaFoto);
        }

        public async Task Update(Foto entity)
        {
            var entityDb = await _dbContext.TblFoto.FindAsync(entity.Id);

            if (entityDb == null) throw new FotoNotFoundException(entity.Id);

            _dbContext.Update(entityDb);

            entityDb.Tanggal = entity.Tanggal;
            entityDb.IdKegiatan = entity.IdKegiatan;
            entityDb.PhotoPath = entity.PhotoPath;
        }
    }
}
