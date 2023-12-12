using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Abstract
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<List<Review>> GetReviewsByUserID(string UserID);
        Task<List<Review>> GetReviewsByProductID(int ProductID);
    }
}
