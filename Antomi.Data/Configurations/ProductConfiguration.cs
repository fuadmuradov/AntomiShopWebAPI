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
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModifiedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.isDeleted).HasDefaultValue(false);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2500);
            builder.Property(x => x.MarkaId).IsRequired();
        }
    }
}
