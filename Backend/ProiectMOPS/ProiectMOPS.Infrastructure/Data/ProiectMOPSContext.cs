using Microsoft.EntityFrameworkCore;
using ProiectMOPS.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProiectMOPS.Infrastructure.Data
{
    public class ProiectMOPSContext : IdentityDbContext<User>
    {
        public ProiectMOPSContext(DbContextOptions<ProiectMOPSContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=(localdb)\local;Initial Catalog=EstateAppDatabase;Integrated Security=True");

            //optionBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EstateAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
