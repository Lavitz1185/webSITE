using Microsoft.EntityFrameworkCore;
using webSITE.Models;

namespace webSITE.Repositori.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mahasiswa>().HasData(
                new Mahasiswa
                {
                    Id = 1,
                    Nim = "2206080051",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    Email = "aditaklal@gmail.com",
                    Password = "adiairnona",
                    PhotoPath = "/img/contoh.jpeg"
                },
                new Mahasiswa
                {
                    Id = 2,
                    Nim = "2206080052",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    Email = "aditaklal@gmail.com",
                    Password = "adiairnona",
                    PhotoPath = "/img/contoh.jpeg"
                },
                new Mahasiswa
                {
                    Id = 3,
                    Nim = "2206080053",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    Email = "aditaklal@gmail.com",
                    Password = "adiairnona",
                    PhotoPath = "/img/contoh.jpeg"
                },
                new Mahasiswa
                {
                    Id = 4,
                    Nim = "2206080054",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    Email = "aditaklal@gmail.com",
                    Password = "adiairnona",
                    PhotoPath = "/img/contoh.jpeg"
                },
                new Mahasiswa
                {
                    Id = 5,
                    Nim = "2206080055",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    Email = "aditaklal@gmail.com",
                    Password = "adiairnona",
                    PhotoPath = "/img/contoh.jpeg"
                },
                new Mahasiswa
                {
                    Id = 6,
                    Nim = "2206080056",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    Email = "aditaklal@gmail.com",
                    Password = "adiairnona",
                    PhotoPath = "/img/contoh.jpeg"
                },
                new Mahasiswa
                {
                    Id = 7,
                    Nim = "2206080057",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    Email = "aditaklal@gmail.com",
                    Password = "adiairnona",
                    PhotoPath = "/img/contoh.jpeg"
                },
                new Mahasiswa
                {
                    Id = 8,
                    Nim = "2206080058",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    Email = "aditaklal@gmail.com",
                    Password = "adiairnona",
                    PhotoPath = "/img/contoh.jpeg"
                }
            );

            modelBuilder.Entity<Kegiatan>().HasData(
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

            modelBuilder.Entity<PesertaKegiatan>().HasData(
                new PesertaKegiatan
                {
                    IdKegiatan = 1,
                    IdMahasiswa = 1,
                },
                new PesertaKegiatan
                {
                    IdKegiatan = 1,
                    IdMahasiswa = 2,
                }
            );

            modelBuilder.Entity<Foto>().HasData(
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

            modelBuilder.Entity<MahasiswaFoto>().HasData(
                new MahasiswaFoto
                {
                    IdFoto = 1,
                    IdMahasiswa = 1,
                },
                new MahasiswaFoto
                {
                    IdFoto = 1,
                    IdMahasiswa = 2,
                },
                new MahasiswaFoto
                {
                    IdFoto = 2,
                    IdMahasiswa = 1,
                },
                new MahasiswaFoto
                {
                    IdFoto = 2,
                    IdMahasiswa = 2,
                },
                new MahasiswaFoto
                {
                    IdFoto = 3,
                    IdMahasiswa = 1,
                },
                new MahasiswaFoto
                {
                    IdFoto = 3,
                    IdMahasiswa = 2,
                },
                new MahasiswaFoto
                {
                    IdFoto = 4,
                    IdMahasiswa = 1,
                },
                new MahasiswaFoto
                {
                    IdFoto = 4,
                    IdMahasiswa = 2,
                },
                new MahasiswaFoto
                {
                    IdFoto = 5,
                    IdMahasiswa = 1,
                },
                new MahasiswaFoto
                {
                    IdFoto = 5,
                    IdMahasiswa = 2,
                }
            );

            modelBuilder.Entity<Kegiatan>().HasMany(k => k.DaftarMahasiswa)
                .WithMany(m => m.DaftarKegiatan)
                .UsingEntity<PesertaKegiatan>(
                    l => l.HasOne<Mahasiswa>().WithMany().HasForeignKey(pk => pk.IdMahasiswa),
                    r => r.HasOne<Kegiatan>().WithMany().HasForeignKey(pk => pk.IdKegiatan)
                );

            modelBuilder.Entity<Mahasiswa>().HasMany(m => m.DaftarFoto)
                .WithMany(f => f.DaftarMahasiswa)
                .UsingEntity<MahasiswaFoto>(
                    l => l.HasOne<Foto>().WithMany().HasForeignKey(mf => mf.IdFoto),
                    r => r.HasOne<Mahasiswa>().WithMany().HasForeignKey(mf => mf.IdMahasiswa)
                );

            modelBuilder.Entity<Foto>().HasOne(f => f.Kegiatan)
                .WithMany(k => k.DaftarFoto)
                .HasForeignKey(f => f.IdKegiatan);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Mahasiswa> TblMahasiswa { get; set; }
        public DbSet<Kegiatan> TblKegiatan { get; set; }
        public DbSet<Foto> TblFoto { get; set; }
        public DbSet<PesertaKegiatan> TblPesertaKegiatan { get; set; }
        public DbSet<MahasiswaFoto> TblMahasiswaFoto { get; set; }
    }
}
