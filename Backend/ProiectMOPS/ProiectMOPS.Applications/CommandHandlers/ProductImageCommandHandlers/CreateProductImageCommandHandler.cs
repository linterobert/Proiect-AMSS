using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Commands.ProductImageCommands;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.CommandHandlers.ProductImageCommandHandlers
{
    public class CreateProductImageCommandHandler: IRequestHandler<CreateProductImageCommand, ProductImage>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductImageCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductImage> Handle(CreateProductImageCommand command, CancellationToken cancellationToken)
        {
            var productImage = new ProductImage();
            productImage.ProductID = command.ProductID;
            productImage.URL = command.URL;

            await _unitOfWork.ProductImageRepository.Create(productImage);
            await _unitOfWork.Save();
            return productImage;
        }
    }
}
