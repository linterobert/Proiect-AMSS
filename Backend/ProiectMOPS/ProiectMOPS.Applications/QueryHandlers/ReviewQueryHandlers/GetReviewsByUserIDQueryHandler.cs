using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Queries.ReviewQueries;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.QueryHandlers.ReviewQueryHandlers
{
    public class GetReviewsByUserIDQueryHandler : IRequestHandler<GetReviewsByUserIDQuery, List<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetReviewsByUserIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Review>> Handle(GetReviewsByUserIDQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ReviewRepository.GetReviewsByUserID(request.UserID);
        }
    }
}
