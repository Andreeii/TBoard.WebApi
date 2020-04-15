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
    public class TournamentRepository : ITournamentRepository
    {
        protected readonly TournamentContext tournamentContext;

        protected DbSet<Tournament> table;

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
