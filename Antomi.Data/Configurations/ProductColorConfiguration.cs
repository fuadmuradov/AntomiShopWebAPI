﻿using Antomi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Data.Configurations
{
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(35);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Count).IsRequired();
        }
    }
}
