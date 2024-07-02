using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _appDbContext.SaveChangesAsync(); 
        }
    }
}
