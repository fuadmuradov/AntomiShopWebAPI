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
    class ProductColorImageConfiguration : IEntityTypeConfiguration<ProductColorImage>
    {
        public void Configure(EntityTypeBuilder<ProductColorImage> builder)
        {
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.IsMain).HasDefaultValue(false);
            builder.Property(x => x.ProductColorId).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModifiedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.isDeleted).HasDefaultValue(false);
        }
    }
}
