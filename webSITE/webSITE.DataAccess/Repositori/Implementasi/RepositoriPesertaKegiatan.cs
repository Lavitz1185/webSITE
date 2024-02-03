using Microsoft.EntityFrameworkCore;
using webSITE.Domain;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriPesertaKegiatan : IRepositoriPesertaKegiatan
    {
        private readonly AppDbContext dbContext;

        public RepositoriPesertaKegiatan(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PesertaKegiatan> Create(string idMahasiswa, int idKegiatan)
        {
            var pesertaKegiatan = await dbContext.TblPesertaKegiatan
                .AsNoTracking()
                .FirstOrDefaultAsync(pk => pk.IdMahasiswa == idMahasiswa && pk.IdKegiatan == idKegiatan);

            if (pesertaKegiatan != null)
                return null;

            pesertaKegiatan = new PesertaKegiatan
            {
                IdMahasiswa = idMahasiswa,
                IdKegiatan = idKegiatan
            };

            dbContext.TblPesertaKegiatan.Add(pesertaKegiatan);

            var result = await dbContext.SaveChangesAsync();
            if (result == 0)
                return null;

            return pesertaKegiatan;
        }

        public async Task<PesertaKegiatan> Delete(string idMahasiswa, int idKegiatan)
        {
            var pesertaKegiatan = await dbContext.TblPesertaKegiatan
                .AsNoTracking()
                .FirstOrDefaultAsync(pk => pk.IdMahasiswa == idMahasiswa && pk.IdKegiatan == idKegiatan);

            if (pesertaKegiatan == null)
                return null;

            dbContext.TblPesertaKegiatan.Remove(pesertaKegiatan);
            await dbContext.SaveChangesAsync();

            return pesertaKegiatan;
        }
    }
}
