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

    }
}
