using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Queries.ProductQueries;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.QueryHandlers.ProductQueryHandlers
{
    public class GetProductByIDQueryHandler : IRequestHandler<GetProductByIDQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductID);
            if (product == null)
            {
                return null;
            }
            return product;
        }
    }
}
