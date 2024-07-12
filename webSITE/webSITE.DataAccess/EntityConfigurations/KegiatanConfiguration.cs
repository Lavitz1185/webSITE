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
            builder.HasMany(k => k.DaftarMahasiswa)
                .WithMany(m => m.DaftarKegiatan)
                .UsingEntity<PesertaKegiatan>(
                    l => l.HasOne<Mahasiswa>().WithMany().HasForeignKey(pk => pk.IdMahasiswa),
                    r => r.HasOne<Kegiatan>().WithMany().HasForeignKey(pk => pk.IdKegiatan)
                );
            builder.Property(m => m.Tanggal).HasColumnType("timestamp without time zone");
            builder.Property(m => m.Keterangan).HasMaxLength(500);
        }
    }
}
