using AutoMapper;
using TBoard.Dto;
using TBoard.Entities;

namespace TBoard.WebApi.Profiles
{
    public class PlayerGameProfile : Profile
    {
        public PlayerGameProfile()
        {
            CreateMap<PlayerGame, PlayerGameDto>();
            CreateMap<PlayerGameDto, PlayerGame>();
        }
    }
}
