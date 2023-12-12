using MediatR;
using ProiectMOPS.Domain.Models;

namespace ProiectMOPS.Applications.Commands.ReviewCommands
{
    public class UpdateReviewCommand : IRequest<Review>
    {
        public string Description { get; set; }
        public int StarNumber { get; set; }
        public int ReviewID { get; set; }
    }
}
