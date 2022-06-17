using Antomi.Core.Entities;
using Antomi.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Data
{
    public class AntomiDbContext:DbContext
    {
        public AntomiDbContext(DbContextOptions<AntomiDbContext> options):base(options)
        {               
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
