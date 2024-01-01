using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using webSITE.Models;
using webSITE.Models.Identity;

namespace webSITE.Data;

public class IdentityContext : IdentityDbContext<AppUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AppUser>().HasOne(u => u.Mahasiswa).WithOne(m => m.AppUser)
            .HasForeignKey<AppUser>(u => u.IdMahasiswa);

        var hasher = new PasswordHasher<AppUser>();

        builder.Entity<Mahasiswa>().HasData(
                new Mahasiswa
                {
                    Id = 1,
                    Nim = "2206080051",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    PhotoPath = "/img/contoh.jpeg"
                }
        );

        builder.Entity<AppUser>().HasData(new AppUser
        {
            Id = "a9c75e44-efd5-4a30-b577-cdb381bdd949",
            Email = "aditaklal@gmail.com",
            NormalizedEmail = "ADITAKLAL@GMAIL.COM",
            IdMahasiswa = 1,
            UserName = "aditaklal@gmail.com",
            NormalizedUserName = "ADITAKLAL@GMAIL.COM",
            PasswordHash = hasher.HashPassword(null, "adiairnona"),
            EmailConfirmed = true
        });

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "57ebc6a3-3e34-45e6-ac93-e234ac4e9b36",
                Name = "Mahasiswa",
                NormalizedName = "MAHASISWA"
            },
            new IdentityRole
            {
                Id = "57ebc6a3-3e34-45e6-ac93-e234ac4e9b37",
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                UserId = "a9c75e44-efd5-4a30-b577-cdb381bdd949",
                RoleId = "57ebc6a3-3e34-45e6-ac93-e234ac4e9b36"
            },
            new IdentityUserRole<string>()
            {
                UserId = "a9c75e44-efd5-4a30-b577-cdb381bdd949",
                RoleId = "57ebc6a3-3e34-45e6-ac93-e234ac4e9b37"
            }
        );

        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
