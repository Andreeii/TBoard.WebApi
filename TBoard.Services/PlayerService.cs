using System;
using System.Collections.Generic;
using System.Text;
using TBoard.Entities;
using TBoard.Repository;
using TBoard.Repository.ResourceParameters;

namespace TBoard.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }
        public void DeleteById(int id)
        {
            playerRepository.DeleteById(id);
        }

        public IEnumerable<Player> GetAll(PlayerResourceParameters playerResourceParameters)
        {
            if (playerResourceParameters == null)
            {
                return playerRepository.GetAll();
            }
            else
            {
                return playerRepository.GetAll(playerResourceParameters);
            }
        }

        public Player GetById(int id)
        {
            var result = playerRepository.GetById(id);
            return result;
        }

        public void Post(Player entity)
        {
            playerRepository.Add(entity);
        }

        public void Update(Player entity)
        {
            playerRepository.Add(entity);
        }
    }
}
