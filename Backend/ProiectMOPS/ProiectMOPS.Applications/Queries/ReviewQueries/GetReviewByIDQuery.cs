using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Queries.ReviewQueries
{
    public class GetReviewByIDQuery : IRequest<Review>
    {
        public int ReviewID { get; set; }
    }
}
