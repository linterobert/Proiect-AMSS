using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Infrastructure.Configurations
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasOne(review => review.Product)
                .WithMany(product => product.Reviews)
                .HasForeignKey(review => review.ProductID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(review => review.User)
                .WithMany(user => user.Reviews)
                .HasForeignKey(review => review.UserID) 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
