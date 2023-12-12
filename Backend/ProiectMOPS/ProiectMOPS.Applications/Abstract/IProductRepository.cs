using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsByUserID(string UserID);
    }
}
