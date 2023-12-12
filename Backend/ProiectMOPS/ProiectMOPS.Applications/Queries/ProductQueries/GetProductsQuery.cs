using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Queries.ProductQueries
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
    }
}
