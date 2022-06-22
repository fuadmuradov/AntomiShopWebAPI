using Antomi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Data.Configurations
{
    public class MarkaConfiguration : IEntityTypeConfiguration<Marka>
    {
        public void Configure(EntityTypeBuilder<Marka> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModifiedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.isDeleted).HasDefaultValue(false);
        }
    }
}
