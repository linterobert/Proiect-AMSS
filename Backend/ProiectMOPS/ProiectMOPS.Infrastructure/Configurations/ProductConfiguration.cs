using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Infrastructure.Configurations
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(product => product.User)
                .WithMany(User => User.Products)
                .HasForeignKey(product => product.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
