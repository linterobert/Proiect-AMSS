using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Commands.ProductCommands;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.CommandHandlers.ProductCommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(command.ProductID);
            if (product == null)
            {
                return null;
            }
            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.Save();
            return product;
        }
    }
}
