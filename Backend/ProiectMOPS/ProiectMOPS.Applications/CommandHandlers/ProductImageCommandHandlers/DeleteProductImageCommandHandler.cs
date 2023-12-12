using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Commands.ProductImageCommands;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.CommandHandlers.ProductImageCommandHandlers
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, ProductImage>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductImageCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductImage> Handle(DeleteProductImageCommand command, CancellationToken cancellationToken)
        {
            var productImage = await _unitOfWork.ProductImageRepository.GetByIdAsync(command.ProductImageID);
            if (productImage == null)
            {
                return null;
            }
            _unitOfWork.ProductImageRepository.Delete(productImage);
            await _unitOfWork.Save();
            return productImage;
        }
    }
}
