using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBoard.Entities;
using TBoard.Repository;

namespace TBoard.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> gameRepository;
        private readonly ITournamentRepository tournamentRepository;

        public GameService(IRepository<Game> gameRepository, ITournamentRepository tournamentRepository)
        {
            this.gameRepository = gameRepository;
            this.tournamentRepository = tournamentRepository;
        }
        public void DeleteById(int id)
        {
            gameRepository.DeleteById(id);
        }

        public IList<Game> GetByTournamentId(int tournamentId)
        {
            return gameRepository.GetAll()
                .Where(x => x.TournamentId == tournamentId)
                .ToList();
        }

        public Game GetById(int id)
        {
            var result = gameRepository.GetById(id);
            return result;
        }

        public void Post(Game entity)
        {
            gameRepository.Add(entity);
        }

        public void Update(Game entity)
        {
            gameRepository.Add(entity);
        }

        public bool Exists(int id)
        {
            if (tournamentRepository.Exists(id) == true)
                return true;
            else
                return false;
        }

        public void SaveChanges()
        {
            gameRepository.SaveChanges();
        }
    }
}
