using Microsoft.EntityFrameworkCore;
using webSITE.Models;
using webSITE.Repositori.Data;
using webSITE.Repositori.Interface;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriMahasiswa : IRepositoriMahasiswa
    {
        private readonly AppDbContext dbContext;

        public RepositoriMahasiswa(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Mahasiswa> Create(Mahasiswa entity)
        {
            var mahasiswa = await dbContext.TblMahasiswa.FirstOrDefaultAsync(m => m.Nim == entity.Nim);
            if(mahasiswa == null)
                await dbContext.AddAsync(entity);

            return mahasiswa;
        }

        public async Task<Mahasiswa> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Mahasiswa> GetByNim(string nim)
        {
            var mahasiswa = await dbContext.TblMahasiswa
                .Include(m => m.DaftarKegiatan)
                .Include(m => m.DaftarFoto)
                .FirstOrDefaultAsync(m => m.Nim == nim);
            return mahasiswa;
        }

        public async Task<Mahasiswa> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Mahasiswa>> GetAll()
        {
            var list = await dbContext.TblMahasiswa.ToListAsync();
            return list;
        }

        public async Task<Mahasiswa> Update(Mahasiswa entity)
        {
            var mahasiswa = await dbContext.TblMahasiswa.FindAsync(entity.Id);
            if(mahasiswa != null )
            {
                dbContext.Update(entity);
            }

            return mahasiswa;
        }
    }
}
