using Microsoft.EntityFrameworkCore;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Domain.Models;
using ProiectMOPS.Infrastructure.Data;

namespace ProiectMOPS.Infrastructure.Repositories
{
    public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(ProiectMOPSContext _context) : base(_context) { }
        public Task<List<ProductImage>> GetProductImagesByProductID(int ProductID)
        {
            return _context.ProductImages.Where(x => x.ProductID == ProductID).ToListAsync();
        }

        public Task<ProductImage> GetProductImageById(int ProductImageID)
        {
            return _context.ProductImages.Where(x => x.ProductImageID == ProductImageID).FirstOrDefaultAsync();
        }

        public async Task<List<ProductImage>> GetAllProductImages()
        {
            return await _context.ProductImages.ToListAsync();
        }

    }
}
