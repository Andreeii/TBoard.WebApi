using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;
using TBoard.Entities.Auth;
using TBoard.WebApi.ResourceParameters;

namespace TBoard.WebApi.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Player GetById(int id);

        IEnumerable<Role> GetAllRoles();

        void DeleteById(int id);

        IEnumerable<Player> GetAll();
        IEnumerable<Player> GetAll(PlayerResourceParameters playerResourceParameters);

        void SaveChanges();
    }
}
