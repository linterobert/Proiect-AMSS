using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Queries.ProductImageQueries
{
    public class GetProductImageByIDQuery : IRequest<ProductImage>
    {
        public int ProductImageID { get; set; }
    }
}
