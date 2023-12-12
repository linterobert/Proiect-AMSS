using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Queries.ReviewQueries;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.QueryHandlers.ReviewQueryHandlers
{
    public class GetReviewByIDQueryHandler : IRequestHandler<GetReviewByIDQuery, Review>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetReviewByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Review> Handle(GetReviewByIDQuery request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(request.ReviewID);
            if (review == null)
            {
                return null;
            }
            return review;
        }
    }
}
