using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public void PostAll(PlayerGame[] playerGames)
        {
            playerGameContext.AddRange(playerGames);
        }

        public IQueryable<PlayerGame> GetAll()
        {
            return playerGameTable;
        }

        public void SaveChanges()
        {
            playerGameContext.SaveChanges();
        }
    }
}

