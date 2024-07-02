using Microsoft.EntityFrameworkCore;
using webSITE.Domain;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain.Exceptions;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriMahasiswa : IRepositoriMahasiswa
    {
        private readonly AppDbContext dbContext;

        public RepositoriMahasiswa(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(Mahasiswa entity)
        {
            var mahasiswa = await Get(entity.Nim);

            if (mahasiswa is not null) throw new MahasiswaDuplicateNimException(entity.Nim);

            dbContext.TblMahasiswa.Add(entity);
        }

        public async Task Delete(string id)
        {
            var mahasiswa = await Get(id);

            if (mahasiswa is null) throw new MahasiswaNotFoundException(id);

            dbContext.TblMahasiswa.Remove(mahasiswa);
        }

        public async Task<Mahasiswa?> GetByNim(string nim)
        {
            var mahasiswa = await dbContext.TblMahasiswa
                .Include(m => m.DaftarKegiatan)
                .Include(m => m.DaftarFoto)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Nim == nim);

            return mahasiswa;
        }

        public async Task<Mahasiswa?> Get(string id)
        {
            return await dbContext.TblMahasiswa
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Mahasiswa>?> GetAll()
        {
            var list = await dbContext.TblMahasiswa
                .AsNoTracking()
                .ToListAsync();

            return list;
        }

        public async Task Update(Mahasiswa entity)
        {
            var mahasiswa = await dbContext.TblMahasiswa.FirstOrDefaultAsync(m => m.Id == entity.Id);

            var mahasiswaNim = await dbContext.TblMahasiswa
                .FirstOrDefaultAsync(m => m.Id != entity.Id && m.Nim == entity.Nim);

            if (mahasiswa is null) throw new MahasiswaFotoNotFoundException(entity.Id);

            if (mahasiswaNim is not null) throw new MahasiswaDuplicateNimException(entity.Nim);

            dbContext.TblMahasiswa.Update(mahasiswa);

            mahasiswa.Nim = entity.Nim;
            mahasiswa.NamaLengkap = entity.NamaLengkap;
            mahasiswa.NamaPanggilan = entity.NamaPanggilan;
            mahasiswa.TanggalLahir = entity.TanggalLahir;
            mahasiswa.JenisKelamin = entity.JenisKelamin;
        }

        public async Task SetProfilePicture(string id, byte[] photoData)
        {
            var mahasiswa = await Get(id);

            if (mahasiswa is null) throw new MahasiswaNotFoundException(id);

            dbContext.Update(mahasiswa);
            mahasiswa.FotoProfil = photoData;
        }

        public async Task AddToFoto(string idMahasiswa, int idFoto)
        {
            var mahasiswaFoto = await dbContext.TblMahasiswaFoto.FindAsync(idMahasiswa, idFoto);

            if (mahasiswaFoto is not null)
                throw new MahasiswaFotoAlreadyExistsException(idFoto, idMahasiswa);

            mahasiswaFoto = new MahasiswaFoto
            {
                IdMahasiswa = idMahasiswa,
                IdFoto = idFoto
            };

            dbContext.TblMahasiswaFoto.Add(mahasiswaFoto);
        }

        public async Task RemoveFromFoto(string idMahasiswa, int idFoto)
        {
            var mahasiswaFoto = await dbContext.TblMahasiswaFoto.FindAsync(idMahasiswa, idFoto);

            if (mahasiswaFoto is null)
                throw new MahasiswaFotoNotFoundException(idFoto, idMahasiswa);

            dbContext.TblMahasiswaFoto.Remove(mahasiswaFoto);
        }

        public async Task AddToKegiatan(string idMahasiswa, int idKegiatan)
        {
            var pesertaKegiatan = await dbContext.TblPesertaKegiatan.FindAsync(idMahasiswa, idKegiatan);

            if (pesertaKegiatan is not null)
                throw new PesertaKegiatanAlreadyExistsException(idKegiatan, idMahasiswa);

            pesertaKegiatan = new PesertaKegiatan
            {
                IdMahasiswa = idMahasiswa,
                IdKegiatan = idKegiatan
            };

            dbContext.TblPesertaKegiatan.Add(pesertaKegiatan);
        }

        public async Task RemoveFromKegiatan(string idMahasiswa, int idKegiatan)
        {
            var pesertaKegiatan = await dbContext.TblPesertaKegiatan.FindAsync(idMahasiswa, idKegiatan);

            if (pesertaKegiatan is null) throw new PesertaKegiatanNotFoundException(idKegiatan, idMahasiswa);

            dbContext.TblPesertaKegiatan.Remove(pesertaKegiatan);
        }

        public async Task<Mahasiswa?> GetWithDetail(string id)
        {
            return await dbContext.TblMahasiswa
                .Include(m => m.DaftarFoto)
                .Include(m => m.DaftarKegiatan)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Mahasiswa>?> GetAllWithDetail()
        {
            return await dbContext.TblMahasiswa
                .Include(m => m.DaftarFoto)
                .Include(m => m.DaftarKegiatan)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
