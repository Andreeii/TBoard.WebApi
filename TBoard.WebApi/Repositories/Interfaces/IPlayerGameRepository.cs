using System;
using System.Collections.Generic;
using System.Linq;
using TBoard.Entities;

namespace TBoard.WebApi.Repositories.Interfaces
{
    public interface IPlayerGameRepository
    {
        public void SaveChanges();
        public IQueryable<PlayerGame> GetAll();

        public void PostAll(PlayerGame[] playerGames);

    }
}
