using Microsoft.EntityFrameworkCore;
using ProiectMOPS.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProiectMOPS.Infrastructure.Configurations;

namespace ProiectMOPS.Infrastructure.Data
{
    public class ProiectMOPSContext : IdentityDbContext<User>
    {
        public ProiectMOPSContext(DbContextOptions<ProiectMOPSContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=DESKTOP-LCU5F5H;Initial Catalog=MOPS;Integrated Security=True");

            //optionBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EstateAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
