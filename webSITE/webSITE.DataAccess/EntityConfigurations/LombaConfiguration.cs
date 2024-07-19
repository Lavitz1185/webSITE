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
    public class LombaConfiguration : IEntityTypeConfiguration<Lomba>
    {
        public void Configure(EntityTypeBuilder<Lomba> builder)
        {
            builder.HasMany(l => l.DaftarPeserta)
                .WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(l => l.DaftarTim)
                .WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
