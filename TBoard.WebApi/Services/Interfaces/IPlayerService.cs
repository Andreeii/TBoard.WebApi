using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Entities.Auth;
using TBoard.WebApi.ResourceParameters;

namespace TBoard.WebApi.Services.Implementation
{
    public interface IPlayerService
    {

        public IEnumerable<PlayerDto> GetAll(PlayerResourceParameters playerResourceParameters);
        public PlayerForCreationDto GetById(int id);
        public void DeleteById(int id);
        public Player AddPlayer(PlayerForCreationDto player);
        public IEnumerable<Role> GetAllRoles();

        public PlayerDto Update(PlayerDto entity);
    }
}
