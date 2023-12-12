using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Commands.ProductImageCommands
{
    public class DeleteProductImageCommand : IRequest<ProductImage>
    {
        public int ProductImageID { get; set; }
    }
}
