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
            modelBuilder.Entity<Mahasiswa>().HasKey(m => m.Nim);

            modelBuilder.Entity<Mahasiswa>().HasData(
                new Mahasiswa
                {
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

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Mahasiswa> TblMahasiswa { get; set; }
    }
}
