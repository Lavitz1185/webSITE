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
    class MahasiswaConfiguration : IEntityTypeConfiguration<Mahasiswa>
    {
        public void Configure(EntityTypeBuilder<Mahasiswa> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.TanggalLahir).HasColumnType("timestamp without time zone");
            builder.HasMany(m => m.DaftarFoto)
               .WithMany(f => f.DaftarMahasiswa)
               .UsingEntity<MahasiswaFoto>(
                   l => l.HasOne<Foto>().WithMany().HasForeignKey(mf => mf.IdFoto),
                   r => r.HasOne<Mahasiswa>().WithMany().HasForeignKey(mf => mf.IdMahasiswa)
               );
            builder.HasIndex(m => m.Nim).IsUnique();
            builder.ToTable("TblMahasiswa");
        }
    }
}
