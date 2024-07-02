using Microsoft.EntityFrameworkCore;
using webSITE.Domain;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain.Exceptions;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriPesertaKegiatan : IRepositoriPesertaKegiatan
    {
        private readonly AppDbContext dbContext;

        public RepositoriPesertaKegiatan(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(string idMahasiswa, int idKegiatan)
        {
            var pesertaKegiatan = await dbContext.TblPesertaKegiatan
                .AsNoTracking()
                .FirstOrDefaultAsync(pk => pk.IdMahasiswa == idMahasiswa && pk.IdKegiatan == idKegiatan);

            if (pesertaKegiatan is not null)
                throw new PesertaKegiatanAlreadyExistsException(idKegiatan, idMahasiswa);

            pesertaKegiatan = new PesertaKegiatan
            {
                IdMahasiswa = idMahasiswa,
                IdKegiatan = idKegiatan
            };

            dbContext.TblPesertaKegiatan.Add(pesertaKegiatan);
        }

        public async Task Delete(string idMahasiswa, int idKegiatan)
        {
            var pesertaKegiatan = await dbContext.TblPesertaKegiatan
                .AsNoTracking()
                .FirstOrDefaultAsync(pk => pk.IdMahasiswa == idMahasiswa && pk.IdKegiatan == idKegiatan);

            if (pesertaKegiatan is null)
                throw new PesertaKegiatanNotFoundException(idKegiatan, idMahasiswa);

            dbContext.TblPesertaKegiatan.Remove(pesertaKegiatan);
        }
    }
}
