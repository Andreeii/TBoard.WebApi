using Microsoft.EntityFrameworkCore;
using System;
using TBoard.Entities;
using TBoard.WebApi.Repositories.Interfaces;

namespace TBoard.WebApi.Repositories.Implementation
{
    public class PlayerGameRepository : IPlayerGameRepository
    {
        protected readonly TournamentContext playerGameContext;

        protected DbSet<PlayerGame> playerGameTable;

        public PlayerGameRepository(TournamentContext playerGameContext)
        {
            this.playerGameContext = playerGameContext;
            playerGameTable = playerGameContext.Set<PlayerGame>();
        }

        public void Post(PlayerGame playerGame)
        {
            if (playerGame == null)
            {
                throw new ArgumentNullException(nameof(playerGame));
            }
            playerGameContext.Add(playerGame);
        }

        public void PostAll(PlayerGame[] playerGames)
        {
            playerGameContext.AddRange(playerGames);
        }

        public void SaveChanges()
        {
            playerGameContext.SaveChanges();
        }
    }
}

