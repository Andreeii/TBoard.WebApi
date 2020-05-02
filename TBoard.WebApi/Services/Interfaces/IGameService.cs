using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;

namespace TBoard.WebApi.Services.Interfaces
{
    public interface IGameService
    {
        public IEnumerable<GameDto> GetAll(int tournamentId);

        public GameDto GetById(int id);
        public void DeleteById(int id);

        public GameDto[] PostAll(GameDto[] games);
        public void Update(Game entity);

        public bool GameExists(int id);

        public void SaveChanges();
    }
}
