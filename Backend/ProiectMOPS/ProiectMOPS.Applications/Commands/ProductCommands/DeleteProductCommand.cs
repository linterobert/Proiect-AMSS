using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Commands.ProductCommands
{
    public class DeleteProductCommand : IRequest<Product>
    {
        public int ProductID { get; set; }
    }
}
