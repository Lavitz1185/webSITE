using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webSITE.Domain;
using webSITE.Domain.Enum;

namespace webSITE.DataAccess.SeedingData
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedingData(this ModelBuilder builder)
        {
            var fotoProfil = File.ReadAllBytes(@"wwwroot/img/student.png");

            var admin = new Mahasiswa[]
            {
                new() {
                    Id = "1",
                    Nim = "2206080051",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    FotoProfil = fotoProfil,
                    Bio = "Adi Juanito Taklal ILKOM #1",
                    Email = "aditaklal@gmail.com",
                    PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "adiairnona"),
                    EmailConfirmed = true,
                    NormalizedEmail = "ADITAKLAL@GMAIL.COM",
                    UserName = "aditaklal@gmail.com",
                    NormalizedUserName = "ADITAKLAL@GMAIL.COM",
                },
                new() {
                    Id = "2",
                    Nim = "2206080016",
                    NamaLengkap = "Oswaldus Putra Fernando",
                    NamaPanggilan = "Fernand",
                    TanggalLahir = new DateTime(2004, 4, 14),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    FotoProfil = fotoProfil,
                    Bio = "Oswaldus Putra Fernando ILKOM #1",
                    Email = "fernandputra14@gmail.com",
                    PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "fernandilkom"),
                    EmailConfirmed = true,
                    NormalizedEmail = "fernandputra14@gmail.com".ToUpper(),
                    UserName = "fernandputra14@gmail.com",
                    NormalizedUserName = "fernandputra14@gmail.com".ToUpper(),
                },
                new() {
                    Id = "3",
                    Nim = "2206080095",
                    NamaLengkap = "Albert Berliano Tapatab",
                    NamaPanggilan = "Albert",
                    TanggalLahir = new DateTime(2004, 1, 7),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    FotoProfil = fotoProfil,
                    Bio = "Albert Berliano Tapatab ILKOM #1",
                    Email = "Lavitz1185@gmail.com",
                    PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "albertilkom"),
                    EmailConfirmed = true,
                    NormalizedEmail = "Lavitz1185@gmail.com".ToUpper(),
                    UserName = "Lavitz1185@gmail.com",
                    NormalizedUserName = "Lavitz1185@gmail.com".ToUpper(),
                    InstagramProfileLink = new Uri("https://www.instagram.com/_all.berliano/")
                },
            };

            builder.Entity<Mahasiswa>().HasData(admin);

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

            builder.Entity<Pengumuman>().HasData(
                new Pengumuman
                {
                    Id = 1,
                    Judul = "Pentas Seni Ilmu Komputer 2024",
                    Isi = "Dengan bangga kami mengundang seluruh civitas akademika untuk menghadiri Pentas Seni Ilmu Komputer 2024 yang akan diselenggarakan pada tanggal 15 Agustus 2024 di Aula Utama Kampus. Acara ini akan menampilkan berbagai pertunjukan seni kreatif dari mahasiswa, termasuk tarian, drama, musik, dan pameran karya digital. Daftar Pensi >> <a href=\"/Pensi\">Klik Untuk Mendaftar Pensi</a> <<",
                    AddedAt = new DateTime(2024, 7, 11, 7, 0, 0, DateTimeKind.Local),
                    IsPriority = true,
                },
                new Pengumuman
                {
                    Id = 2,
                    Judul = "Dies Natalies Ilmu Komputer 2025 ",
                    Isi = "Coming Soon !!!!. ",
                    AddedAt = new DateTime(2024, 7, 11, 7, 0, 0, DateTimeKind.Local),
                    IsPriority = false,
                }
            );

            builder.Entity<Lomba>().HasData(
                new
                {
                    Id = 1,
                    Nama = "Menyanyi",
                    Jenis = JenisLomba.Solo,
                    MaksKuotaPerAngkatan = 2,
                    LinkGrupWa = new Uri("http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM"),
                    PDFPath = "/pdf/Csharp_in_Depth_4th_Edition.pdf"
                },
                new
                {
                    Id = 2,
                    Nama = "Desain Poster",
                    Jenis = JenisLomba.Solo,
                    MaksKuotaPerAngkatan = 2,
                    LinkGrupWa = new Uri("http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM"),
                    PDFPath = "/pdf/Csharp_in_Depth_4th_Edition.pdf"
                },
                new
                {
                    Id = 3,
                    Nama = "Menari",
                    Jenis = JenisLomba.Tim,
                    MaksKuotaPerAngkatan = 2,
                    MinAnggotaPerTim = 5,
                    MaksAnggotaPerTim = 10,
                    LinkGrupWa = new Uri("http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM"),
                    PDFPath = "/pdf/Csharp_in_Depth_4th_Edition.pdf"
                },
                new
                {
                    Id = 4,
                    Nama = "Fashion Show",
                    Jenis = JenisLomba.Pasangan,
                    MaksKuotaPerAngkatan = 2,
                    PasanganBedaJenisKelamin = true,
                    LinkGrupWa = new Uri("http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM"),
                    PDFPath = "/pdf/Csharp_in_Depth_4th_Edition.pdf"
                }
            );

            return builder;
        }
    }
}
