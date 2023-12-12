using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Queries.ProductQueries
{
    public class GetProductsByUserIDQuery: IRequest<List<Product>>
    {
        public string UserID { get; set; }  
    }
}
