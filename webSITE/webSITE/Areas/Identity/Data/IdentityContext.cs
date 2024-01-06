using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webSITE.Models;

namespace webSITE.Data;

public class IdentityContext : IdentityDbContext<Mahasiswa>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<Mahasiswa>().HasData(
            new Mahasiswa
            {
                Id = 1,
                Nim = "2206080051",
                NamaLengkap = "Adi Juanito Taklal",
                NamaPanggilan = "Adi",
                TanggalLahir = new DateTime(2004, 2, 29),
                JenisKelamin = JenisKelamin.LakiLaki,
                PhotoPath = "/img/contoh.jpeg",
                Email = "aditaklal@gmail.com",
                PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "adiairnona"),
                EmailConfirmed = true,
                NormalizedEmail = "ADITAKLAL@GMAIL.COM",
                UserName = "aditaklal@gmail.com",
                NormalizedUserName = "ADITAKLAL@GMAIL.COM",
            }
       );

        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>
            {
                Id = 1,
                Name = "Mahasiswa",
                NormalizedName = "MAHASISWA"
            },
            new IdentityRole<int>
            {
                Id = 2,
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        );

        builder.Entity<IdentityUserRole<int>>().HasKey(iur => new { iur.UserId, iur.RoleId });

        builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>
            {
                UserId = 1,
                RoleId = 1
            },
            new IdentityUserRole<int>
            {
                UserId = 1,
                RoleId = 2
            }
        );
    }
}
