using AutoMapper;
using FootballManager.Application.Features.Players.Commands.CreatePlayer;
using FootballManager.Domain.Entities;

namespace FootballManager.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //CreateMap<Player, GetAllPlayersViewModel>().ReverseMap();
            CreateMap<CreatePlayerCommand, Player>();
            //CreateMap<GetAllPlayersQuery, GetAllPlayersParameter>();
        }
    }
}
