using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Queries.ProductImageQueries;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.QueryHandlers.ProductImageQueryHandlers
{
    public class GetProductImageByIDQueryHandler : IRequestHandler<GetProductImageByIDQuery, ProductImage>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductImageByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductImage> Handle(GetProductImageByIDQuery request, CancellationToken cancellationToken)
        {
            var productImage = await _unitOfWork.ProductImageRepository.GetByIdAsync(request.ProductImageID);
            if (productImage == null)
            {
                return null;
            }
            return productImage;
        }
    }
}
