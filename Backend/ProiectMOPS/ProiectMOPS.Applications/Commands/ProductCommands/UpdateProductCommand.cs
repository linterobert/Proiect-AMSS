using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Commands.ProductCommands
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
