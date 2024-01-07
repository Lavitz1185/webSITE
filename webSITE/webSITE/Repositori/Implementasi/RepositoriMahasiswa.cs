using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
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

        public async Task<Mahasiswa> Delete(string id)
        {
            var mahasiswa = await dbContext.TblMahasiswa
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mahasiswa == null)
                return null;

            dbContext.TblMahasiswa.Remove(mahasiswa);
            await dbContext.SaveChangesAsync();

            return mahasiswa;
        }

        public async Task<Mahasiswa> GetByNim(string nim)
        {
            var mahasiswa = await dbContext.TblMahasiswa
                .Include(m => m.DaftarKegiatan)
                .Include(m => m.DaftarFoto)
                .FirstOrDefaultAsync(m => m.Nim == nim);
            return mahasiswa;
        }

        public async Task<Mahasiswa> Get(string id)
        {
            return await dbContext.TblMahasiswa
                .AsNoTracking()
                .Include(m => m.DaftarFoto)
                .Include(m => m.DaftarKegiatan)
                .FirstOrDefaultAsync(m => m.Id == id);
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
