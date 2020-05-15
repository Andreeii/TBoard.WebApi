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

        protected DbSet<Tournament> tournamentTable;

        public TournamentRepository(TournamentContext context)
        {
            tournamentContext = context;
            tournamentTable = context.Set<Tournament>();
        }

        public Tournament Add(Tournament entity)
        {
            var tournament = tournamentContext.Add(entity);
            return tournament.Entity;
        }

        public void DeleteById(int id)
        {
            Tournament existing = tournamentTable.Find(id);
            tournamentTable.Remove(existing);
        }

        public bool Exists(int id)
        {
            if (tournamentTable.Find(id) != null)
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
            return tournamentTable;
        }


        public Tournament GetById(int id)
        {
            var tournament = tournamentTable
                .Include(tournament => tournament.Game)
                .ThenInclude(game => game.PlayerGame)
                .FirstOrDefault(x => x.Id == id);

            return tournament;
        }

        public void Update(Tournament entity)
        {
            entity.CreationDate = DateTime.Now;
            tournamentContext.Update(entity);
        }
        public void SaveChanges()
        {
            tournamentContext.SaveChanges();
        }
    }
}
