using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webSITE.Domain;

namespace webSITE.DataAccess.EntityConfigurations;

class MahasiswaConfiguration : IEntityTypeConfiguration<Mahasiswa>
{
    public void Configure(EntityTypeBuilder<Mahasiswa> builder)
    {
        builder.HasIndex(m => m.Nim);
        builder.Property(m => m.TanggalLahir).HasColumnType("timestamp without time zone");
        builder.Property(m => m.FacebookProfileLink).HasConversion<UriToStringConverter>();
        builder.Property(m => m.InstagramProfileLink).HasConversion<UriToStringConverter>();
        builder.Property(m => m.TikTokProfileLink).HasConversion<UriToStringConverter>();
        builder.Property(m => m.Bio).HasMaxLength(Mahasiswa.MaxBioLength);
        builder.HasMany(m => m.DaftarFoto).WithMany(f => f.DaftarMahasiswa);
        builder.ToTable("TblMahasiswa");
    }
}
