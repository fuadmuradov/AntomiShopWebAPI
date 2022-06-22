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
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModifiedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.isDeleted).HasDefaultValue(false);
            builder.Property(x => x.CategoryId).IsRequired();
        }
    }
}
