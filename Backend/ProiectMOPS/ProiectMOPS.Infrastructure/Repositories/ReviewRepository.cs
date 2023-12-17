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
        public Task<Review> GetReviewByID(int ReviewID)
        {
            return _context.Reviews.Where(x => x.ReviewID == ReviewID).FirstOrDefaultAsync();
        }
        public async Task<List<Review>> GetAllReviews()
        {
            return await _context.Reviews.ToListAsync();
        }
    }
}
