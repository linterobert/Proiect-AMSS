using AutoMapper;
using ProiectMOPS.Applications.Commands.ProductCommands;
using ProiectMOPS.Domain.DTOs;

namespace ProiectMOPS.WebApp.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        { 
            CreateMap<CreateProductDTO, CreateProductCommand>().ReverseMap();
            CreateMap<UpdateProductDTO, UpdateProductCommand>().ReverseMap();
        }
    }
}
