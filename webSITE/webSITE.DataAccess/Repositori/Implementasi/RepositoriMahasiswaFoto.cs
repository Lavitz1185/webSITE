using webSITE.Domain;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain.Exceptions;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriMahasiswaFoto : IRepositoriMahasiswaFoto
    {
        private readonly AppDbContext dbContext;

        public RepositoriMahasiswaFoto(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(string idMahasiswa, int idFoto)
        {
            var mahasiswaFoto = await dbContext.TblMahasiswaFoto.FindAsync(idFoto, idMahasiswa);

            if (mahasiswaFoto is not null)
                throw new MahasiswaFotoAlreadyExistsException(idFoto, idMahasiswa);

            mahasiswaFoto = new MahasiswaFoto
            {
                IdMahasiswa = idMahasiswa,
                IdFoto = idFoto
            };

            dbContext.TblMahasiswaFoto.Add(mahasiswaFoto);
        }

        public async Task Delete(string idMahasiswa, int idFoto)
        {
            var mahasiswaFoto = await dbContext.TblMahasiswaFoto.FindAsync(idFoto, idMahasiswa);

            if (mahasiswaFoto is null)
                throw new MahasiswaFotoNotFoundException(idFoto, idMahasiswa);

            dbContext.TblMahasiswaFoto.Remove(mahasiswaFoto);
        }
    }
}
