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
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductColorImage> productColorImages { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<PhoneSpecification> PhoneSpecifications { get; set; }
        public DbSet<NotebookSpecification> NotebookSpecifications { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TestimonialConfiguration());
            modelBuilder.ApplyConfiguration(new SettingConfiguration());
            modelBuilder.ApplyConfiguration(new MarkaConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductColorConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductColorImageConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountConfiguration());
            modelBuilder.ApplyConfiguration(new SpecificationConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneSpecificationConfiguration());
            modelBuilder.ApplyConfiguration(new NotebookSpecificationConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());



        }
    }
}
