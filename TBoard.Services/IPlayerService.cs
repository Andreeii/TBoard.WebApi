using System;
using System.Collections.Generic;
using System.Text;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Repository.ResourceParameters;

namespace TBoard.Services
{
    public interface IPlayerService
    {

        public IEnumerable<PlayerDto> GetAll(PlayerResourceParameters playerResourceParameters);
        public PlayerDto GetById(int id);
        public void DeleteById(int id);
        public Player AddPlayer(PlayerDto entity);

        public PlayerDto Update(PlayerDto entity);
    }
}
