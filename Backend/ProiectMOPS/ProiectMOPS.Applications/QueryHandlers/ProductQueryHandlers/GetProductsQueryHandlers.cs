using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Queries.ProductQueries;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.QueryHandlers.ProductQueryHandlers
{
    public class GetProductsQueryHandlers : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductsQueryHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.GetAll();
        }
    }
}
