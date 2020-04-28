using System;

using TBoard.Entities;

namespace TBoard.WebApi.Repositories.Interfaces
{
    public interface IPlayerGameRepository
    {
        public void Post(PlayerGame playerGame);
        public void SaveChanges();
        public void PostAll(PlayerGame[] playerGames);

    }
}
