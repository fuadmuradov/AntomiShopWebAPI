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
    public class HomeCategoryConfiguration : IEntityTypeConfiguration<HomeCategory>
    {
        public void Configure(EntityTypeBuilder<HomeCategory> builder)
        {
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();

        }
    }
}
