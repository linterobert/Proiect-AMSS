using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Queries.ProductImageQueries
{
    public class GetProductImagesByProductIDQuery : IRequest<List<ProductImage>>
    {
        public int ProductID { get; set; }
    }
}
