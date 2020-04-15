using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBoard.Entities;
using TBoard.Infrastructure;
using TBoard.Repository.ResourceParameters;

namespace TBoard.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        protected readonly TournamentContext tournamentContext;

        protected DbSet<Player> table;

        public PlayerRepository(TournamentContext context)
        {
            tournamentContext = context;
            table = context.Set<Player>();
        }

        public void Add(Player entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            tournamentContext.Add(entity);
        }

        public void DeleteById(int id)
        {
            Player existing = table.Find(id);
            table.Remove(existing);
        }

        public bool Exists(int id)
        {
            if (table.Find(id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<Player> GetAll()
        {
            return table.ToList();
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
            return table.Find(id);
        }

        public void Update(Player entity)
        {
            tournamentContext.Entry(entity).State = EntityState.Modified;
        }
        public void SaveChanges()
        {
            tournamentContext.SaveChanges();
        }
    }
}
