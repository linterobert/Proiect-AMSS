using MediatR;
using ProiectMOPS.Domain.DTOs;
using ProiectMOPS.Domain.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace ProiectMOPS.Applications.Commands.ReviewCommands
{
    public class CreateReviewCommand : IRequest<Review>
    {
        public string Description { get; set; }
        public string UserID { get; set; }
        public int StarNumber { get; set; }
        public int ProductID { get; set; }

        public CreateReviewCommand(CreateReviewDTO dto)
        {

            Description = dto.Description;
            StarNumber = dto.StarNumber;
        }
    }
}
