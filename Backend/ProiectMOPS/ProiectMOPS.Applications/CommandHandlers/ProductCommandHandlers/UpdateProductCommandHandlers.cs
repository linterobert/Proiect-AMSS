using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Commands.ProductCommands;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.CommandHandlers.ProductCommandHandlers
{
    public class UpdateProductCommandHandlers : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(command.ProductID);
            if(product == null)
            {
                return null;
            }

            product.Price = command.Price;
            product.Description = command.Description;
            product.Name = command.Description;
            product.UpdateTime = DateTime.Now;
            await _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.Save();
            return product;
        }
    }
}
