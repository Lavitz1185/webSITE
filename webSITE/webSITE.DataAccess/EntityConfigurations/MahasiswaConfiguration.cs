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
            builder.HasIndex(m => m.Nim);
            builder.Property(m => m.TanggalLahir).HasColumnType("timestamp without time zone");
            builder.HasMany(m => m.DaftarFoto).WithMany(f => f.DaftarMahasiswa);
            builder.ToTable("TblMahasiswa");
        }
    }
}
