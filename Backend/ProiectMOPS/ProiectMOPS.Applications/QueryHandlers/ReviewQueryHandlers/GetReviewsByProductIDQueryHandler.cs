using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Queries.ReviewQueries;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.QueryHandlers.ReviewQueryHandlers
{
    public class GetReviewsByProductIDQueryHandler : IRequestHandler<GetReviewsByProductIDQuery, List<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetReviewsByProductIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Review>> Handle(GetReviewsByProductIDQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ReviewRepository.GetReviewsByProductID(request.ProductID);
        }
    }
}
