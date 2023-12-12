using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Commands.ProductImageCommands
{
    public class CreateProductImageCommand: IRequest<ProductImage>
    {
        public string URL { get; set; }
        public int ProductID { get; set; }
    }
}
