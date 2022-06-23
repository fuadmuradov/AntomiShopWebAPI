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
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Text).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Username).HasMaxLength(40);
            builder.Property(x => x.isActive).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.Email).HasMaxLength(150);
            builder.Property(x => x.ProductId).IsRequired();

        }
    }
}
