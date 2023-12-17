using MediatR;
using ProiectMOPS.Domain.DTOs;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Commands.ProductImageCommands
{
    public class CreateProductImageCommand: IRequest<ProductImage>
    {
        public string URL { get; set; }
        public int ProductID { get; set; }
        public CreateProductImageCommand(CreateProductImageDTO dto)
        {
            this.URL = dto.URL;
            this.ProductID = dto.ProductID;
        }
    }
}
