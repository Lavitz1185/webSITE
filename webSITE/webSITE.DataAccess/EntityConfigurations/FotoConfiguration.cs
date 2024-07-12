using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain;

namespace webSITE.DataAccess.EntityConfigurations
{
    internal class FotoConfiguration : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.HasOne(f => f.Kegiatan)
               .WithMany(k => k.DaftarFoto)
               .HasForeignKey(f => f.IdKegiatan);
            builder.Property(m => m.Tanggal).HasColumnType("timestamp without time zone");
        }
    }
}
