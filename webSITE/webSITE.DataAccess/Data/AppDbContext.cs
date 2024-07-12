using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using webSITE.Configuration;
using webSITE.DataAccess.EntityConfigurations;
using webSITE.DataAccess.SeedingData;
using webSITE.Domain;

namespace webSITE.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<Mahasiswa>
    {
        private readonly PhotoFileSettings _photoFileSettings;

        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<PhotoFileSettings> photoFileOptions)
            : base(options)
        {
            _photoFileSettings = photoFileOptions.Value;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(ConfigurationAssemblyReference.Assembly);

            builder.SeedingData();
        }

        public DbSet<Mahasiswa> TblMahasiswa { get; set; }
        public DbSet<Kegiatan> TblKegiatan { get; set; }
        public DbSet<Foto> TblFoto { get; set; }
        public DbSet<PesertaKegiatan> TblPesertaKegiatan { get; set; }
        public DbSet<MahasiswaFoto> TblMahasiswaFoto { get; set; }
        public DbSet<Pengumuman> TblPengumuman { get; set; }
    }
}
