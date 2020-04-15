using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Repository;
using TBoard.Repository.ResourceParameters;

namespace TBoard.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;
        private readonly IMapper mapper;


        public PlayerService(IPlayerRepository playerRepository,IMapper mapper)
        {
            this.playerRepository = playerRepository;
            this.mapper = mapper;
        }
        public void DeleteById(int id)
        {
            playerRepository.DeleteById(id);
            playerRepository.SaveChanges();
        }

        public IEnumerable<PlayerDto> GetAll(PlayerResourceParameters playerResourceParameters)
        {
            IEnumerable<Player> result;
            if (playerResourceParameters == null)
            {
                result = playerRepository.GetAll();
                return mapper.Map<IEnumerable<PlayerDto>>(result);
            }
            else
            {
                result = playerRepository.GetAll(playerResourceParameters);
                return mapper.Map<IEnumerable<PlayerDto>>(result);
            }
        }

        public PlayerDto GetById(int playerId)
        {
            var result = playerRepository.GetById(playerId);
            return mapper.Map<PlayerDto>(result);
        }

        public Player AddPlayer(PlayerDto player)
        {
            var playerEntity = mapper.Map<Player>(player);
            playerRepository.Add(playerEntity);
            playerRepository.SaveChanges();
            var playerToreturn = mapper.Map<Player>(playerEntity);
            return playerToreturn;
        }

        public PlayerDto Update(PlayerDto player)
        {
            var playerEntity = mapper.Map<Player>(player);
            playerRepository.Update(playerEntity);
            playerRepository.SaveChanges();
            var playerToReturn = mapper.Map<PlayerDto>(playerEntity);
            return playerToReturn;
        }
    }
}
