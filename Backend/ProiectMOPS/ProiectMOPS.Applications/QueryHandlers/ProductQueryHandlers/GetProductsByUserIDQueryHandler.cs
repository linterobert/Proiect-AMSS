using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Queries.ProductQueries;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.QueryHandlers.ProductQueryHandlers
{
    public class GetProductsByUserIDQueryHandler: IRequestHandler<GetProductsByUserIDQuery, List<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductsByUserIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> Handle(GetProductsByUserIDQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.GetProductsByUserID(request.UserID);
        }
    }
}
