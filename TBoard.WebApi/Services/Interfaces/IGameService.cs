using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;

namespace TBoard.WebApi.Services.Interfaces
{
    public interface IGameService
    {
        public IList<Game> GetByTournamentId(int tournamentId);
        public Game GetById(int id);
        public void DeleteById(int id);
        public void Post(Game entity);

        public void Update(Game entity);

        public bool Exists(int id);

        public void SaveChanges();
    }
}
