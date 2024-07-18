using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;
using Microsoft.AspNetCore.Http;

namespace webSITE.DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly HttpContext _httpContext;

        public UnitOfWork(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AuditAuditableEntity();
            return _appDbContext.SaveChangesAsync(); 
        }

        private void AuditAuditableEntity()
        {
            var addedEntries = _appDbContext.ChangeTracker.Entries<IAuditableEntity>()
                .Where(e => e.State == EntityState.Added);

            var modifiedEntries = _appDbContext.ChangeTracker.Entries<IAuditableEntity>()
                .Where(e => e.State == EntityState.Modified);

            var userName = _httpContext.User.Claims.Where(c => c.Type == ClaimTypes.Name)
                .Select(c => c.Value)
                .FirstOrDefault();
            var user = _appDbContext.TblMahasiswa.Where(u => u.UserName == userName).FirstOrDefault();

            if (addedEntries != null && addedEntries.Count() > 0)
            {
                foreach (var entry in addedEntries)
                {
                    entry.Entity.AddedAt = DateTime.Now;
                    entry.Entity.Creator = user;
                }
            }

            if (modifiedEntries != null && modifiedEntries.Count() > 0)
            {
                foreach (var entry in modifiedEntries)
                {
                    entry.Entity.ModifiedAt = DateTime.Now;
                }
            }
        }
    }
}
