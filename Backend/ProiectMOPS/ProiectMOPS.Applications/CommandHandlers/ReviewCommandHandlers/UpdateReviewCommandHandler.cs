using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Commands.ReviewCommands;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.CommandHandlers.ReviewCommandHandlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Review>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Review> Handle(UpdateReviewCommand command, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(command.ReviewID);
            if (review == null)
            {
                return null;
            }

            review.Description = command.Description;
            review.UpdatedTime = DateTime.Now;
            review.StarNumber = command.StarNumber;
            await _unitOfWork.ReviewRepository.Update(review);
            await _unitOfWork.Save();
            return review;
        }
    }
}
