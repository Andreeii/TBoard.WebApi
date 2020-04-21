using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;
using TBoard.WebApi.Repositories.Interfaces;
using TBoard.WebApi.ResourceParameters;

namespace TBoard.WebApi.Repositories.Implementation
{
    public class TournamentRepository : ITournamentRepository
    {
        protected readonly TournamentContext tournamentContext;

        protected DbSet<Tournament> table;
        protected DbSet<Game> gtable;
        protected DbSet<Player> ptable;
        protected DbSet<PlayerGame> pgtable;

        public TournamentRepository(TournamentContext context)
        {
            tournamentContext = context;
            table = context.Set<Tournament>();
        }

        public void Add(Tournament entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            tournamentContext.Add(entity);
        }

        public void DeleteById(int id)
        {
            Tournament existing = table.Find(id);
            table.Remove(existing);
        }

        //public Player GetTournamentWinner(int tournamentId)
        //{
        //    var result = table.Where(x => x.TournamentId == tournamentId)
        //        .Include(x => x.Game)
        //        .ThenInclude(x => x))
        //        .FirstOrDefault();

        //}

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
        public IEnumerable<Tournament> GetAll()
        {
            return table.ToList();
        }

        public IEnumerable<Tournament> GetAll(TournamentResourceParameters tournamentResourceParameters)
        {
            var collection = tournamentContext.Tournament as IQueryable<Tournament>;
            if (tournamentResourceParameters == null)
            {
                return GetAll();
            }
            else if (!string.IsNullOrWhiteSpace(tournamentResourceParameters.SearchQuery))
            {
                var searchQuery = tournamentResourceParameters.SearchQuery.Trim();
                collection = collection
                    .Where(a => a.Name.Contains(searchQuery));
            }
            return collection.ToList();
        }

        public Tournament GetById(int id)
        {
            return table.Find(id);
        }

        public void Update(Tournament entity)
        {
            tournamentContext.Entry(entity).State = EntityState.Modified;
        }
        public void SaveChanges()
        {
            tournamentContext.SaveChanges();
        }
    }
}
