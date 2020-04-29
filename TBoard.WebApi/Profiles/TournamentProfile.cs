using AutoMapper;
using TBoard.Dto;
using TBoard.Entities;

namespace TBoard.WebApi.Profiles
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            CreateMap<Tournament, TournamentDto>();
            CreateMap<TournamentDto, Tournament>();

        }
    }
}
