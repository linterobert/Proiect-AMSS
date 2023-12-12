using AutoMapper;
using ProiectMOPS.Applications.Commands.ProductImageCommands;
using ProiectMOPS.Domain.DTOs;

namespace ProiectMOPS.WebApp.Profiles
{
    public class ProductImageProfile: Profile
    {
        public ProductImageProfile()
        {
            CreateMap<CreateProductImageDTO, CreateProductImageCommand>().ReverseMap();
        }
    }
}
