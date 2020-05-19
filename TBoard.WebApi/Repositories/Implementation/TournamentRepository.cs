using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TBoard.Entities;
using TBoard.WebApi.Repositories.Interfaces;

namespace TBoard.WebApi.Repositories.Implementation
{
    public class TournamentRepository : ITournamentRepository
    {
        protected readonly TournamentContext tournamentContext;

        public TournamentRepository(TournamentContext tournamentContext)
        {
            this.tournamentContext = tournamentContext;
        }

        public Tournament Add(Tournament entity)
        {
            var tournament = tournamentContext.Add(entity);
            return tournament.Entity;
        }

        public void DeleteById(int id)
        {
            Tournament existing = tournamentContext.Tournaments.Find(id);
            tournamentContext.Tournaments.Remove(existing);
        }

        public IEnumerable<Tournament> GetAll()
        {
            return tournamentContext.Tournaments;
        }

        public Tournament GetById(int id)
        {
            var tournament = tournamentContext.Tournaments
                .Include(tournament => tournament.Games)
                .ThenInclude(game => game.PlayerGames)
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
