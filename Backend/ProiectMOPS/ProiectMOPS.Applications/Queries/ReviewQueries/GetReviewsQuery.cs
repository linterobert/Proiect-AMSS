using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Queries.ReviewQueries
{
    public class GetReviewsQuery : IRequest<List<Review>>
    {
    }
}
