using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Queries.ProductImageQueries
{
    public class GetProductImagesQuery : IRequest<List<ProductImage>>
    {
    }
}
