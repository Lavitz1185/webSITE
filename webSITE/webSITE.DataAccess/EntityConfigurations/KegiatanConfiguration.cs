using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webSITE.Domain;

namespace webSITE.DataAccess.EntityConfigurations;

internal class KegiatanConfiguration : IEntityTypeConfiguration<Kegiatan>
{
    public void Configure(EntityTypeBuilder<Kegiatan> builder)
    {
        builder.HasMany(k => k.DaftarMahasiswa).WithMany(m => m.DaftarKegiatan);
        builder.HasMany(k => k.DaftarFoto).WithMany(f => f.DaftarKegiatan);
        builder.HasOne(k => k.FotoThumbnail).WithMany().OnDelete(DeleteBehavior.SetNull);
        builder.Property(m => m.Tanggal).HasColumnType("timestamp without time zone");
    }
}
