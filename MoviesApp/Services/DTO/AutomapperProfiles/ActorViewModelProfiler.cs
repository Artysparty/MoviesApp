using AutoMapper;
using MoviesApp.Models;
using MoviesApp.Services.DTO;
using MoviesApp.ViewModels;

namespace MoviesApp.Services.Dto.AutoMapperProfiles
{
    public class ActorDtoProfile : Profile
    {
        public ActorDtoProfile()
        {
            CreateMap<Actor, ActorDto>().ReverseMap();
        }
    }
}