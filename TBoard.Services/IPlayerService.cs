using System;
using System.Collections.Generic;
using System.Text;
using TBoard.Entities;
using TBoard.Repository.ResourceParameters;

namespace TBoard.Services
{
    public interface IPlayerService
    {

        public IEnumerable<Player> GetAll(PlayerResourceParameters playerResourceParameters);
        public Player GetById(int id);
        public void DeleteById(int id);
        public void Post(Player entity);

        public void Update(Player entity);
    }
}
