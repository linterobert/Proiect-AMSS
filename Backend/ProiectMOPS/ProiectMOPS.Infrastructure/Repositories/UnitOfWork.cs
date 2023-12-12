using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Infrastructure.Data;

namespace ProiectMOPS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProiectMOPSContext _context;

        public UnitOfWork(ProiectMOPSContext context, IProductRepository productRepository, 
            IProductImageRepository productImageRepository, IReviewRepository reviewRepository)
        {
            _context = context;
            ProductRepository = productRepository;
            ProductImageRepository = productImageRepository;
            ReviewRepository = reviewRepository;
        }

        public IProductRepository ProductRepository { get; private set; }
        public IProductImageRepository ProductImageRepository { get; private set; }
        public IReviewRepository ReviewRepository { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
