using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Commands.ReviewCommands
{
    public class DeleteReviewCommand: IRequest<Review>
    {
        public int ReviewID { get; set; }
    }
}
