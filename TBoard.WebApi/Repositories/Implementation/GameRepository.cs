using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;
using TBoard.WebApi.Repositories.Interfaces;

namespace TBoard.WebApi.Repositories.Implementation
{
    public class GameRepository:IGameRepository
    {
        protected readonly TournamentContext gameContext;

        protected DbSet<Tournament> tournamentTable;
        protected DbSet<Game> gameTable;

        public GameRepository(TournamentContext context)
        {
            gameContext = context;
            gameTable = context.Set<Game>();
        }

        public void DeleteById(int id)
        {
            Game existing = gameTable.Find(id);
            gameTable.Remove(existing);
        }

        public IEnumerable<Game> GetByTournamentId(int tournamentId)
        {
            return gameTable
                .Where(x => x.TournamentId == tournamentId)
                .ToList();
        }

        public Game GetById(int id)
        {
            return gameTable.Find(id);

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
        public void Post(Game entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            using (var transaction = gameContext.Database.BeginTransaction())
            {
                gameContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Game] ON");
                gameContext.Add(entity);
                gameContext.SaveChanges();
                gameContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Game] OFF");
                transaction.Commit();
            }
        }

        public void Update(Game entity)
        {
            gameContext.Entry(entity).State = EntityState.Modified;
        }

  

        public bool GameExists(int id)
        {
            if (gameTable.Find(id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SaveChanges()
        {
            gameContext.SaveChanges();
        }
    }


}

