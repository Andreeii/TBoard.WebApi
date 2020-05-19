using System.Collections.Generic;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Entities.Auth;

namespace TBoard.WebApi.Services.Interfaces
{
    public interface IPlayerService
    {

        public IEnumerable<PlayerDto> GetAll();
        public PlayerForUpdateDto GetById(int id);
        public Player DeleteById(int id);
        public IEnumerable<Role> GetAllRoles();

    }
}
