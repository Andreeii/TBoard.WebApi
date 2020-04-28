
using TBoard.Dto;

namespace TBoard.WebApi.Services.Interfaces
{
    public interface IPlayerGameService
    {
        public PlayerGameDto Post(PlayerGameDto playerGame);
        public PlayerGameDto[] PostAll(PlayerGameDto[] playerGames);


    }
}
