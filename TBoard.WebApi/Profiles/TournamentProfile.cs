using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;

namespace TBoard.WebApi.Profiles
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            CreateMap<Tournament, TournamentDto>();
            CreateMap<TournamentForCreationDto, Tournament>();
            CreateMap<TournamentDto, Tournament>();

        }
    }
}
