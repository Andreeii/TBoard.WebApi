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

        public TournamentRepository(TournamentContext context)
        {
            tournamentContext = context;
            table = context.Set<Tournament>();
        }

        public void Add(Tournament entity)
        {
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
            return table;
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
