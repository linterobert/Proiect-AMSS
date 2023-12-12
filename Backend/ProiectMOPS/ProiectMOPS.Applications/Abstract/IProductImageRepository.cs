using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Abstract
{
    public interface IProductImageRepository : IGenericRepository<ProductImage>
    {
        Task<List<ProductImage>> GetProductImagesByProductID(int ProductID);
    }
}
