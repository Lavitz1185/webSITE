using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webSITE.DataAccess.ValueConverters;
using webSITE.Domain;

namespace webSITE.DataAccess.EntityConfigurations
{
    public class LombaConfiguration : IEntityTypeConfiguration<Lomba>
    {
        public void Configure(EntityTypeBuilder<Lomba> builder)
        {
            builder.Property(l => l.LinkGrupWa).HasConversion<UriValueConverter>();

            builder.HasMany(l => l.DaftarPeserta)
                .WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(l => l.DaftarTim)
                .WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(l => l.FotoLomba)
                .WithMany().OnDelete(DeleteBehavior.SetNull);
        }
    }
}
