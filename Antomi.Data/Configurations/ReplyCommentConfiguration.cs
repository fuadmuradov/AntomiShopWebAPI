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
    public class ReplyCommentConfiguration : IEntityTypeConfiguration<ReplyComment>
    {
        public void Configure(EntityTypeBuilder<ReplyComment> builder)
        {

            builder.Property(x => x.Text).IsRequired().HasMaxLength(150);
            builder.Property(x => x.BlogCommentId).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
