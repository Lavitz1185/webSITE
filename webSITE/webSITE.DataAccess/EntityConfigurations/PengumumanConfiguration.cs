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
    internal class PengumumanConfiguration : IEntityTypeConfiguration<Pengumuman>
    {
        public void Configure(EntityTypeBuilder<Pengumuman> builder)
        {
            builder.HasOne(p => p.Foto).WithMany().OnDelete(DeleteBehavior.SetNull);
        }
    }
}
