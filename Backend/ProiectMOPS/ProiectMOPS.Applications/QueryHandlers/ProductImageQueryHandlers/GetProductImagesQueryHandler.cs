using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Queries.ProductImageQueries;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.QueryHandlers.ProductImageQueryHandlers
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQuery, List<ProductImage>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductImagesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ProductImage>> Handle(GetProductImagesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductImageRepository.GetAll();
        }
    }
}
