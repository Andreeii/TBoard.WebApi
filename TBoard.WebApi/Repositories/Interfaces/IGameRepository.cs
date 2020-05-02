using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;

namespace TBoard.WebApi.Repositories.Interfaces
{
    public interface IGameRepository
    {

        public void PostAll(Game[] games);

        public void DeleteById(int id);
        public  Game GetById(int id);
        public IEnumerable<Game> GetByTournamentId(int tournamentId);

        public IEnumerable<Game> GetAll();

        public void Update(Game entity);

        public bool GameExists(int id);

        public void SaveChanges();
    }
}
