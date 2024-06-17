using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using webSITE.Configuration;
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

            builder.Entity<Mahasiswa>().HasKey(m => m.Id);

            builder.Entity<Mahasiswa>().Property(m => m.TanggalLahir).HasColumnType("timestamp without time zone");

            builder.Entity<Kegiatan>().HasMany(k => k.DaftarMahasiswa)
                .WithMany(m => m.DaftarKegiatan)
                .UsingEntity<PesertaKegiatan>(
                    l => l.HasOne<Mahasiswa>().WithMany().HasForeignKey(pk => pk.IdMahasiswa),
                    r => r.HasOne<Kegiatan>().WithMany().HasForeignKey(pk => pk.IdKegiatan)
                );

            builder.Entity<Kegiatan>().Property(m => m.Tanggal).HasColumnType("timestamp without time zone");

            builder.Entity<Mahasiswa>().HasMany(m => m.DaftarFoto)
                .WithMany(f => f.DaftarMahasiswa)
                .UsingEntity<MahasiswaFoto>(
                    l => l.HasOne<Foto>().WithMany().HasForeignKey(mf => mf.IdFoto),
                    r => r.HasOne<Mahasiswa>().WithMany().HasForeignKey(mf => mf.IdMahasiswa)
                );

            builder.Entity<Foto>().HasOne(f => f.Kegiatan)
                .WithMany(k => k.DaftarFoto)
                .HasForeignKey(f => f.IdKegiatan);

            builder.Entity<Foto>().Property(m => m.Tanggal).HasColumnType("timestamp without time zone");

            builder.Entity<Mahasiswa>().ToTable("TblMahasiswa");

            string fotoProfilPath1 = @"wwwroot\img\student.png";
            string fotoProfilPath2 = @"wwwroot\img\SIte_Transparant.png";
            string fotoProfilPath3 = @"wwwroot\img\generaluser.png";

            var admin = new Mahasiswa[]
            {
                new Mahasiswa
                {
                    Id = "1",
                    Nim = "2206080051",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    FotoProfil = File.ReadAllBytes(fotoProfilPath1),
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
                    FotoProfil = File.ReadAllBytes(fotoProfilPath2),
                    StatusAkun = StatusAkun.Aktif,
                    Bio = "Oswaldus Putra Fernando ILKOM #1",
                    Email = "fernandputra14@gmail.com",
                    PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "fernandilkom"),
                    EmailConfirmed = true,
                    NormalizedEmail = "fernandputra14@gmail.com".ToUpper(),
                    UserName = "fernandputra14@gmail.com",
                    NormalizedUserName = "fernandputra14@gmail.com".ToUpper(),
                },
                new Mahasiswa
                {
                    Id = "3",
                    Nim = "2206080095",
                    NamaLengkap = "Albert Berliano Tapatab",
                    NamaPanggilan = "Albert",
                    TanggalLahir = new DateTime(2004, 1, 7),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    FotoProfil = File.ReadAllBytes(fotoProfilPath3),
                    StatusAkun = StatusAkun.Aktif,
                    Bio = "Albert Berliano Tapatab ILKOM #1",
                    Email = "Lavitz1185@gmail.com",
                    PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "albertilkom"),
                    EmailConfirmed = true,
                    NormalizedEmail = "Lavitz1185@gmail.com".ToUpper(),
                    UserName = "Lavitz1185@gmail.com",
                    NormalizedUserName = "Lavitz1185@gmail.com".ToUpper(),
                },
            };

            var daftarMahasiswa = new Mahasiswa[] 
            {

            };

            builder.Entity<Mahasiswa>().HasData(admin);

            var defaultEmail = "site@undana.com";
            builder.Entity<Mahasiswa>().HasData(daftarMahasiswa.Select((m ,i) => new Mahasiswa
            {
                Id = (4 + i).ToString(),
                TanggalLahir = new DateTime(2005, 1, 1),
                FotoProfil = File.ReadAllBytes(fotoProfilPath1),
                StatusAkun = StatusAkun.Aktif,
                Bio = "ILKOM #1",
                Email = defaultEmail,
                PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "site"),
                EmailConfirmed = true,
                NormalizedEmail = defaultEmail.ToUpper(),
                UserName = defaultEmail,
                NormalizedUserName = defaultEmail.ToUpper(),
            }));

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
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData
            (
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "1",
                },
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "2",
                },
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "3",
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "1",
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "2",
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "3",
                },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "1",
                },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "2",
                },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "3",
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData
            (
                daftarMahasiswa.Select(m => new IdentityUserRole<string>
                {
                    UserId = m.Id,
                    RoleId = "1",
                }).ToArray()
            );

            builder.Entity<Kegiatan>().HasData(
                new Kegiatan
                {
                    Id = 1,
                    NamaKegiatan = "Foto Angkatan SITE",
                    Tanggal = new DateTime(2023, 12, 03),
                    JumlahHari = 1,
                    Keterangan = "Kegiatan Pertama",
                    TempatKegiatan = "Undana"
                },
                new Kegiatan
                {
                    Id = 2,
                    NamaKegiatan = "Kegiatan 1",
                    Tanggal = new DateTime(2023, 12, 03),
                    JumlahHari = 3,
                    Keterangan = "Kegiatan Pertama",
                    TempatKegiatan = "Undana"
                }
            );

            builder.Entity<PesertaKegiatan>().HasData(
                new PesertaKegiatan
                {
                    IdKegiatan = 1,
                    IdMahasiswa = "1",
                },
                new PesertaKegiatan
                {
                    IdKegiatan = 1,
                    IdMahasiswa = "2",
                },
                new PesertaKegiatan
                {
                    IdKegiatan = 1,
                    IdMahasiswa = "3",
                },
                new PesertaKegiatan
                {
                    IdKegiatan = 2,
                    IdMahasiswa = "2",
                }
            );

            string root = _photoFileSettings.StoredFilesPath;

            builder.Entity<Foto>().HasData(
                new Foto
                {
                    Id = 1,
                    IdKegiatan = 1,
                    PhotoPath = Path.Combine(root, "Front_Building.jpg"),
                    Tanggal = new DateTime(2023, 12, 03),
                },
                new Foto
                {
                    Id = 2,
                    IdKegiatan = 2,
                    PhotoPath = Path.Combine(root, "contoh.jpeg"),
                    Tanggal = new DateTime(2023, 12, 04),
                },
                new Foto
                {
                    Id = 3,
                    IdKegiatan = 2,
                    PhotoPath = Path.Combine(root, "contoh.jpeg"),
                    Tanggal = new DateTime(2023, 12, 04),
                },
                new Foto
                {
                    Id = 4,
                    IdKegiatan = 2,
                    PhotoPath = Path.Combine(root, "contoh.jpeg"),
                    Tanggal = new DateTime(2023, 12, 05),
                },
                new Foto
                {
                    Id = 5,
                    IdKegiatan = 2,
                    PhotoPath = Path.Combine(root, "contoh.jpeg"),
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
                    IdFoto = 1,
                    IdMahasiswa = "2",
                },
                new MahasiswaFoto
                {
                    IdFoto = 1,
                    IdMahasiswa = "3",
                },
                new MahasiswaFoto
                {
                    IdFoto = 2,
                    IdMahasiswa = "2",
                },
                new MahasiswaFoto
                {
                    IdFoto = 3,
                    IdMahasiswa = "2",
                },
                new MahasiswaFoto
                {
                    IdFoto = 4,
                    IdMahasiswa = "2",
                },
                new MahasiswaFoto
                {
                    IdFoto = 5,
                    IdMahasiswa = "2",
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
