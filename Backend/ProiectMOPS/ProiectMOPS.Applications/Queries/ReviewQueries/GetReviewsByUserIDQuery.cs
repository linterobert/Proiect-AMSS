using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Queries.ReviewQueries
{
    public class GetReviewsByUserIDQuery : IRequest<List<Review>>
    {
        public string UserID { get; set; }
    }
}
