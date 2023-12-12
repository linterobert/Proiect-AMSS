using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Commands.ReviewCommands;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.CommandHandlers.ReviewCommandHandlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Review>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Review> Handle(CreateReviewCommand command, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(command.ProductID);

            if(product == null)
            {
                return null;
            }

            var review = new Review();
            review.ProductID = command.ProductID;
            review.UserID = command.UserID;
            review.StarNumber = command.StarNumber;
            review.Description = command.Description;
            review.CreatedTime = DateTime.Now;
            review.UpdatedTime = DateTime.Now;

            await _unitOfWork.ReviewRepository.Create(review);
            await _unitOfWork.Save();
            return review;
        }
    }
}
