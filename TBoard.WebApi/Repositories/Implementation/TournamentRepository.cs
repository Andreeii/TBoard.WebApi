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

        public object GetTournamentWinner()
        {
            var q1 = tournamentContext.PlayerGame
                .Where(x => x.IsWinner == true)
                .GroupBy(x => new { x.PlayerId, x.Game.TournamentId })
                .Select(x => new
                {
                    PlayerId = x.Key.PlayerId,
                    TournamentId = x.Key.TournamentId,
                    Wins = x.Count()

                });
            var q2 = tournamentContext.PlayerGame
                 .Where(x => x.IsWinner == true)
                 .GroupBy(x => new { x.PlayerId, x.Game.TournamentId, x.Game.Tournament.Name, x.Player.UserName })
                 .Select(x => new
                      {
                        PlayerId = x.Key.PlayerId,
                        TournamentId = x.Key.TournamentId,
                        NumberOfWins = x.Count(),
                        WinnerName = x.Key.UserName,
                        TournamentName = x.Key.Name

                       })
                 .Where(x => x.NumberOfWins == q1.Where(y => y.TournamentId == x.TournamentId).Max(y => y.Wins)).ToList();

            return q2;
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
