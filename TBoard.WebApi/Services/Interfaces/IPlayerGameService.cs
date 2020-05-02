
using System.Collections;
using System.Collections.Generic;
using TBoard.Dto;
using TBoard.Entities;

namespace TBoard.WebApi.Services.Interfaces
{
    public interface IPlayerGameService
    {
        public PlayerGameDto[] PostAll(PlayerGameDto[] playerGames);


    }
}
