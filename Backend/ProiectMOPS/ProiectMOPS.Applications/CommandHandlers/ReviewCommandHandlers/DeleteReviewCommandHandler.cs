using MediatR;
using ProiectMOPS.Applications.Abstract;
using ProiectMOPS.Applications.Commands.ReviewCommands;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.CommandHandlers.ReviewCommandHandlers
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Review>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Review> Handle(DeleteReviewCommand command, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(command.ReviewID);
            if (review == null)
            {
                return null;
            }
            _unitOfWork.ReviewRepository.Delete(review);
            await _unitOfWork.Save();
            return review;
        }
    }
}
