using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;

namespace TBoard.WebApi.Profiles
{
    public class PlayerGameProfile:Profile
    {
        public PlayerGameProfile()
        {
            CreateMap<PlayerGame, PlayerGameDto>();
            CreateMap<PlayerGameDto, PlayerGame>();
        }
    }
}
