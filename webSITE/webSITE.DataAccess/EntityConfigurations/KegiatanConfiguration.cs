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
    internal class KegiatanConfiguration : IEntityTypeConfiguration<Kegiatan>
    {
        public void Configure(EntityTypeBuilder<Kegiatan> builder)
        {
            builder.HasMany(k => k.DaftarMahasiswa).WithMany(m => m.DaftarKegiatan);
            builder.HasMany(k => k.DaftarFoto).WithMany(f => f.DaftarKegiatan);
            builder.Property(m => m.Tanggal).HasColumnType("timestamp without time zone");
            builder.Property(m => m.Keterangan).HasMaxLength(500);
        }
    }
}
