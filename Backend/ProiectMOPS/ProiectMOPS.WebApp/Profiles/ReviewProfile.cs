using AutoMapper;
using ProiectMOPS.Applications.Commands.ReviewCommands;
using ProiectMOPS.Domain.DTOs;

namespace ProiectMOPS.WebApp.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile() 
        {
            CreateMap<CreateReviewDTO, CreateReviewCommand>().ReverseMap();
            CreateMap<UpdateReviewDTO, UpdateReviewCommand>().ReverseMap();
        }
    }
}
