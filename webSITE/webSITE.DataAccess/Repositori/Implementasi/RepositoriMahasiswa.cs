using Microsoft.EntityFrameworkCore;
using webSITE.Domain;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain.Exceptions;
using webSITE.Domain.Exceptions.MahasiswaExceptions;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriMahasiswa : IRepositoriMahasiswa
    {
        private readonly AppDbContext dbContext;

        public RepositoriMahasiswa(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Mahasiswa?> Get(string id)
        {
            return await dbContext.TblMahasiswa.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Mahasiswa?> GetWithDetail(string id)
        {
            return await dbContext.TblMahasiswa
                .Include(m => m.DaftarFoto)
                .Include(m => m.DaftarKegiatan)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Mahasiswa?> GetByNim(string nim)
        {
            var mahasiswa = await dbContext.TblMahasiswa
                .Include(m => m.DaftarKegiatan)
                .Include(m => m.DaftarFoto)
                .FirstOrDefaultAsync(m => m.Nim == nim);

            return mahasiswa;
        }

        public async Task<List<Mahasiswa>?> GetAll()
        {
            var list = await dbContext.TblMahasiswa
                .ToListAsync();

            return list;
        }

        public async Task<List<Mahasiswa>?> GetAllWithDetail()
        {
            return await dbContext.TblMahasiswa
                .Include(m => m.DaftarFoto)
                .Include(m => m.DaftarKegiatan)
                .ToListAsync();
        }

        public void Add(Mahasiswa entity)
        {
            dbContext.TblMahasiswa.Add(entity);
        }

        public async Task Delete(string id)
        {
            var mahasiswa = await Get(id);

            if (mahasiswa is null) throw new MahasiswaNotFoundException(id);

            dbContext.TblMahasiswa.Remove(mahasiswa);
        }

        public void Update(Mahasiswa entity)
        {
            dbContext.TblMahasiswa.Update(entity);
        }
    }
}