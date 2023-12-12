using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Commands.ProductCommands;
using ProiectMOPS.Domain.Models;
namespace ProiectMOPS.Applications.CommandHandlers.ProductCommandHandlers
{
    public class CreateProductCommandHandlers: IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;
            product.CreateTime = DateTime.Now;
            product.UpdateTime = DateTime.Now;
            product.UserID = command.UserID;

            await _unitOfWork.ProductRepository.Create(product);
            await _unitOfWork.Save();
            return product;
        }
    }
}
