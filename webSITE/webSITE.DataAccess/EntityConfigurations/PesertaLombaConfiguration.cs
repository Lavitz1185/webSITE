using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webSITE.DataAccess.ValueConverters;
using webSITE.Domain;

namespace webSITE.DataAccess.EntityConfigurations
{
    public class PesertaLombaConfiguration : IEntityTypeConfiguration<PesertaLomba>
    {
        public void Configure(EntityTypeBuilder<PesertaLomba> builder)
        {
            builder.Property(p => p.Nim).HasConversion<NimValueConverter>();
            builder.HasIndex(p => p.Nim).IsUnique();
            builder.Property(p => p.NoWa).HasConversion<NoWaValueConverter>();
            builder.Property(p => p.TanggalDaftar).HasColumnType("timestamp without time zone");
        }
    }
}
