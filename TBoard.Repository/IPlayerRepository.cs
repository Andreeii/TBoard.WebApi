using System;
using System.Collections.Generic;
using System.Text;
using TBoard.Entities;
using TBoard.Repository.ResourceParameters;

namespace TBoard.Repository
{
    public interface IPlayerRepository
    {
        //find objects
        Player GetById(int id);

        //add objects
        void Add(Player entity);

        //remove objects
        void DeleteById(int id);

        IEnumerable<Player> GetAll();
        IEnumerable<Player> GetAll(PlayerResourceParameters playerResourceParameters);
        //update
        void Update(Player entity);

        bool Exists(int id);

        public void SaveChanges();
    }
}
