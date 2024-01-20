using Microsoft.EntityFrameworkCore;
using webSITE.Domain;
using webSITE.Repositori.Data;
using webSITE.Repositori.Interface;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriMahasiswaFoto : IRepositoriMahasiswaFoto
    {
        private readonly AppDbContext dbContext;

        public RepositoriMahasiswaFoto(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MahasiswaFoto> Create(string idMahasiswa, int idFoto)
        {
            var mahasiswaFoto = await dbContext.TblMahasiswaFoto.FindAsync(idFoto, idMahasiswa);

            if (mahasiswaFoto != null)
                return null;

            mahasiswaFoto = new MahasiswaFoto
            {
                IdMahasiswa = idMahasiswa,
                IdFoto = idFoto
            };

            dbContext.TblMahasiswaFoto.Add(mahasiswaFoto);
            var result = await dbContext.SaveChangesAsync();
            if (result == 0)
                return null;

            return mahasiswaFoto;
        }

        public async Task<MahasiswaFoto> Delete(string idMahasiswa, int idFoto)
        {
            var mahasiswaFoto = await dbContext.TblMahasiswaFoto.FindAsync(idFoto, idMahasiswa);

            if (mahasiswaFoto == null)
                return null;

            dbContext.TblMahasiswaFoto.Remove(mahasiswaFoto);
            await dbContext.SaveChangesAsync();

            return mahasiswaFoto;
        }
    }
}
