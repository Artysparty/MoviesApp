using System.Collections.Generic;
using MoviesApp.Models;
using MoviesApp.Services.Dto;
using MoviesApp.Services.DTO;

namespace MoviesApp.Services
{
    public interface IActorService
    {
        ActorDto GetActor(int id);
        IEnumerable<ActorDto> GetAllActors();
        ActorDto UpdateActor(ActorDto actorDto);
        ActorDto AddActor(ActorDto actorDto);
        ActorDto DeleteActor(int id);
    }
}
