using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Entities.Auth;
using TBoard.WebApi.Repositories.Interfaces;
using TBoard.WebApi.ResourceParameters;

namespace TBoard.WebApi.Services.Implementation
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;
        private readonly IMapper mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            this.playerRepository = playerRepository;
            this.mapper = mapper;
        }
        public void DeleteById(int id)
        {
            playerRepository.DeleteById(id);
            playerRepository.SaveChanges();
        }

        public IEnumerable<Role> GetAllRoles()
        {
           return  playerRepository.GetAllRoles().ToList();
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

        public Player AddPlayer(PlayerForCreationDto player)
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
