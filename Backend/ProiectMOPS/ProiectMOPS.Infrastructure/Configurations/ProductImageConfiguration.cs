using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Infrastructure.Configurations
{
    public class ProductImageConfiguration: IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasOne(image => image.Product)
                .WithMany(product => product.Images)
                .HasForeignKey(image => image.ProductID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
