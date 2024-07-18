using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
using webSITE.Configuration;
using webSITE.DataAccess.EntityConfigurations;
using webSITE.DataAccess.SeedingData;
using webSITE.Domain;
using webSITE.Domain.Abstractions;

namespace webSITE.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<Mahasiswa>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();

            foreach (var entityType in entityTypes)
            {
                if (typeof(IAuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).Property(nameof(IAuditableEntity.AddedAt))
                        .HasColumnType("timestamp without time zone");
                    modelBuilder.Entity(entityType.ClrType).Property(nameof(IAuditableEntity.ModifiedAt))
                        .HasColumnType("timestamp without time zone");
                    modelBuilder.Entity(entityType.ClrType).HasOne(nameof(IAuditableEntity.Creator))
                        .WithMany().OnDelete(DeleteBehavior.SetNull);
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(ConfigurationAssemblyReference.Assembly);

            modelBuilder.SeedingData();
        }

        public DbSet<Mahasiswa> TblMahasiswa { get; set; }
        public DbSet<Kegiatan> TblKegiatan { get; set; }
        public DbSet<Foto> TblFoto { get; set; }
        public DbSet<Pengumuman> TblPengumuman { get; set; }
    }
}
