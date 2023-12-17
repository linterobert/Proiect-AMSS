using Microsoft.EntityFrameworkCore;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Domain.Models;
using ProiectMOPS.Infrastructure.Data;
using System.Diagnostics.Contracts;

namespace ProiectMOPS.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ProiectMOPSContext _context) : base(_context) { }

        public Task<List<Product>> GetProductsByUserID(string UserID)
        {
            return _context.Products.Where(x => x.UserID == UserID).ToListAsync();
        }
        public Task<Product> GetProductByID(int ProductID)
        {
            return _context.Products.Where(x => x.ProductID == ProductID).FirstOrDefaultAsync();
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
