using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Queries.ReviewQueries
{
    public class GetReviewsByProductIDQuery : IRequest<List<Review>>
    {
        public int ProductID { get; set; }  
    }
}
