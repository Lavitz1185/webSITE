using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webSITE.Domain;

namespace webSITE.DataAccess.EntityConfigurations
{
    public class TimLombaConfiguration : IEntityTypeConfiguration<TimLomba>
    {
        public void Configure(EntityTypeBuilder<TimLomba> builder)
        {
            builder.HasMany(t => t.AnggotaTim).WithOne();
            builder.Property(t => t.TanggalDaftar).HasColumnType("timestamp without time zone");
        }
    }
}
