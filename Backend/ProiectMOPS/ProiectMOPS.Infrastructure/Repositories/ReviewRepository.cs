using Microsoft.EntityFrameworkCore;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Domain.Models;
using ProiectMOPS.Infrastructure.Data;

namespace ProiectMOPS.Infrastructure.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ProiectMOPSContext _context) : base(_context) { }

        public Task<List<Review>> GetReviewsByProductID(int ProductID)
        {
            return _context.Reviews.Where(x => x.ProductID == ProductID).ToListAsync();
        }

        public Task<List<Review>> GetReviewsByUserID(string UserID)
        {
            return _context.Reviews.Where(x => x.UserID == UserID).ToListAsync();
        }
    }
}
