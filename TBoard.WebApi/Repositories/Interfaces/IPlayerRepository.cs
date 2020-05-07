using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;
using TBoard.WebApi.ResourceParameters;

namespace TBoard.WebApi.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Player GetById(int id);

        public Player Add(Player player);

        void DeleteById(int id);

        IEnumerable<Player> GetAll();
        IEnumerable<Player> GetAll(PlayerResourceParameters playerResourceParameters);
        void Update(Player entity);

        bool Exists(int id);

        public void SaveChanges();
    }
}
