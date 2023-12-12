using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Queries.ProductQueries
{
    public class GetProductByIDQuery: IRequest<Product>
    {
        public int ProductID { get; set; }
    }
}
