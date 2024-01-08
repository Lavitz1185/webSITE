using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webSITE.Models;

namespace webSITE.Repositori.Data
{
    public class AppDbContext : IdentityDbContext<Mahasiswa>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Mahasiswa>().HasKey(m => m.Id);

            builder.Entity<Kegiatan>().HasMany(k => k.DaftarMahasiswa)
                .WithMany(m => m.DaftarKegiatan)
                .UsingEntity<PesertaKegiatan>(
                    l => l.HasOne<Mahasiswa>().WithMany().HasForeignKey(pk => pk.IdMahasiswa),
                    r => r.HasOne<Kegiatan>().WithMany().HasForeignKey(pk => pk.IdKegiatan)
                );

            builder.Entity<Mahasiswa>().HasMany(m => m.DaftarFoto)
                .WithMany(f => f.DaftarMahasiswa)
                .UsingEntity<MahasiswaFoto>(
                    l => l.HasOne<Foto>().WithMany().HasForeignKey(mf => mf.IdFoto),
                    r => r.HasOne<Mahasiswa>().WithMany().HasForeignKey(mf => mf.IdMahasiswa)
                );

            builder.Entity<Foto>().HasOne(f => f.Kegiatan)
                .WithMany(k => k.DaftarFoto)
                .HasForeignKey(f => f.IdKegiatan);

            builder.Entity<Mahasiswa>().ToTable("TblMahasiswa");

            builder.Entity<Mahasiswa>().HasData(
                new Mahasiswa
                {
                    Id = "1",
                    Nim = "2206080051",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    PhotoPath = "/img/SIte_Transparant.png",
                    StatusAkun = StatusAkun.Aktif,
                    Bio = "Adi Juanito Taklal ILKOM #1",
                    Email = "aditaklal@gmail.com",
                    PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "adiairnona"),
                    EmailConfirmed = true,
                    NormalizedEmail = "ADITAKLAL@GMAIL.COM",
                    UserName = "aditaklal@gmail.com",
                    NormalizedUserName = "ADITAKLAL@GMAIL.COM",
                },
                new Mahasiswa
                {
                    Id = "2",
                    Nim = "2206080016",
                    NamaLengkap = "Oswaldus Putra Fernando",
                    NamaPanggilan = "Fernand",
                    TanggalLahir = new DateTime(2004, 4, 14),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    PhotoPath = "/img/SIte_Transparant.png",
                    Bio = "Oswaldus Putra Fernando ILKOM #1",
                    Email = "fernandputra14@gmail.com",
                    StatusAkun = StatusAkun.Aktif,
                    PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "fernandilkom"),
                    EmailConfirmed = true,
                    NormalizedEmail = "fernandputra14@gmail.com".ToUpper(),
                    UserName = "fernandputra14@gmail.com",
                    NormalizedUserName = "fernandputra14@gmail.com".ToUpper(),
                }
           );

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Mahasiswa",
                    NormalizedName = "MAHASISWA"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    UserId = "1",
                    RoleId = "1"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "1",
                    RoleId = "2",
                },
                new IdentityUserRole<string>()
                {
                    UserId = "2",
                    RoleId = "1"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "2",
                    RoleId = "2",
                }
            );

            builder.Entity<Kegiatan>().HasData(
                new Kegiatan
                {
                    Id = 1,
                    NamaKegiatan = "Kegiatan 1",
                    TanggalMulai = new DateTime(2023, 12, 03),
                    TanggalBerakhir = new DateTime(2023, 12, 07),
                    Keterangan = "Kegiatan Pertama",
                    TempatKegiatan = "Undana"
                }
            );

            builder.Entity<PesertaKegiatan>().HasData(
                new PesertaKegiatan
                {
                    IdKegiatan = 1,
                    IdMahasiswa = "1",
                }
            );

            builder.Entity<Foto>().HasData(
                new Foto
                {
                    Id = 1,
                    IdKegiatan = 1,
                    PhotoPath = "/img/contoh.jpeg",
                    Tanggal = new DateTime(2023, 12, 03),
                },
                new Foto
                {
                    Id = 2,
                    IdKegiatan = 1,
                    PhotoPath = "/img/contoh.jpeg",
                    Tanggal = new DateTime(2023, 12, 04),
                },
                new Foto
                {
                    Id = 3,
                    IdKegiatan = 1,
                    PhotoPath = "/img/contoh.jpeg",
                    Tanggal = new DateTime(2023, 12, 04),
                },
                new Foto
                {
                    Id = 4,
                    IdKegiatan = 1,
                    PhotoPath = "/img/contoh.jpeg",
                    Tanggal = new DateTime(2023, 12, 05),
                },
                new Foto
                {
                    Id = 5,
                    IdKegiatan = 1,
                    PhotoPath = "/img/contoh.jpeg",
                    Tanggal = new DateTime(2023, 12, 06),
                }
            );

            builder.Entity<MahasiswaFoto>().HasData(
                new MahasiswaFoto
                {
                    IdFoto = 1,
                    IdMahasiswa = "1",
                },
                new MahasiswaFoto
                {
                    IdFoto = 2,
                    IdMahasiswa = "1",
                },
                new MahasiswaFoto
                {
                    IdFoto = 3,
                    IdMahasiswa = "1",
                },
                new MahasiswaFoto
                {
                    IdFoto = 4,
                    IdMahasiswa = "1",
                },
                new MahasiswaFoto
                {
                    IdFoto = 5,
                    IdMahasiswa = "1",
                }
            );
        }

        public DbSet<Mahasiswa> TblMahasiswa { get; set; }
        public DbSet<Kegiatan> TblKegiatan { get; set; }
        public DbSet<Foto> TblFoto { get; set; }
        public DbSet<PesertaKegiatan> TblPesertaKegiatan { get; set; }
        public DbSet<MahasiswaFoto> TblMahasiswaFoto { get; set; }
    }
}
