using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Queries.ReviewQueries;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.QueryHandlers.ReviewQueryHandlers
{
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, List<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetReviewsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Review>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ReviewRepository.GetAll();
        }
    }
}
