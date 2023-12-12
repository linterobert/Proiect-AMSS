using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Commands.ReviewCommands
{
    public class CreateReviewCommand : IRequest<Review>
    {
        public string Description { get; set; }
        public string UserID { get; set; }
        public int StarNumber { get; set; }
        public int ProductID { get; set; }
    }
}
