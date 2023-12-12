using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Queries.ProductImageQueries;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.QueryHandlers.ProductImageQueryHandlers
{
    public class GetProductImagesByProductIDQueryHandler : IRequestHandler<GetProductImagesByProductIDQuery, List<ProductImage>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductImagesByProductIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ProductImage>> Handle(GetProductImagesByProductIDQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductImageRepository.GetProductImagesByProductID(request.ProductID);
        }
    }
}
