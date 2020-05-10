using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;
using TBoard.Entities.Auth;
using TBoard.WebApi.Repositories.Interfaces;
using TBoard.WebApi.ResourceParameters;

namespace TBoard.WebApi.Repositories.Implementation
{
    public class PlayerRepository : IPlayerRepository
    {
        protected readonly TournamentContext tournamentContext;

        protected DbSet<Player> playerTable;
        protected DbSet<Role> rolesTable;

        public PlayerRepository(TournamentContext context)
        {
            tournamentContext = context;
            playerTable = context.Set<Player>();
            rolesTable = context.Set<Role>();
        }

        public void DeleteById(int id)
        {
            Player existing = playerTable.Find(id);
            playerTable.Remove(existing);
        }

        public IEnumerable<Player> GetAll()
        {
            return playerTable.ToList();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return rolesTable;
        }

        public IEnumerable<Player> GetAll(PlayerResourceParameters playerResourceParameters)
        {
            var collection = tournamentContext.Player as IQueryable<Player>;
            if (playerResourceParameters == null)
            {
                return GetAll();
            }
            else if (!string.IsNullOrWhiteSpace(playerResourceParameters.SearchQuery))
            {
                var searchQuery = playerResourceParameters.SearchQuery.Trim();
                collection = collection
                    .Where(a => a.UserName.Contains(searchQuery));
            }
            return collection.ToList();
        }

        public Player GetById(int id)
        {
            return playerTable.Find(id);
        }

        public void SaveChanges()
        {
            tournamentContext.SaveChanges();
        }
    }
}
