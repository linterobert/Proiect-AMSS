namespace ProiectMOPS.Applications.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        public IProductImageRepository ProductImageRepository { get; }
        public IReviewRepository ReviewRepository { get; }

        Task Save();
    }
}
