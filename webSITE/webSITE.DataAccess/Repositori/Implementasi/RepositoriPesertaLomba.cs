using Microsoft.EntityFrameworkCore;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Domain.Exceptions.PesertaLombaExceptions;

namespace webSITE.DataAccess.Repositori.Implementasi
{
    public class RepositoriPesertaLomba : IRepositoriPesertaLomba
    {
        private readonly AppDbContext _appDbContext;

        public RepositoriPesertaLomba(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(PesertaLomba pesertaLomba)
        {
            _appDbContext.Add(pesertaLomba);
        }

        public async Task Delete(int id)
        {
            var pesertaLomba = await _appDbContext
                .TblPesertaLomba.FirstOrDefaultAsync(pe => pe.Id == id);

            if (pesertaLomba is null)
                throw new PesertaLombaNotFoundException($"Peserta Lomba dengan ID : {id} tidak ditemukan");

            _appDbContext.TblPesertaLomba.Remove(pesertaLomba);
        }
    }
}
