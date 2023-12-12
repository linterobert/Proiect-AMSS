using MediatR;
using ProiectMOPS.Domain.DTOs;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Commands.ProductCommands
{
    public class CreateProductCommand: IRequest<Product>
    {
        public CreateProductCommand() { }
        public CreateProductCommand(CreateProductDTO dto)
        {
            UserID = dto.UserID;
            Price = dto.Price;
            Description = dto.Description;
            Name = dto.Name;
        }
        public string UserID { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
