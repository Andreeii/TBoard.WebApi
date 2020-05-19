using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Entities.Auth;
using TBoard.WebApi.Repositories.Interfaces;
using TBoard.WebApi.Services.Interfaces;

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
        public Player DeleteById(int id)
        {
            var deletedPlayer = playerRepository.DeleteById(id);
            playerRepository.SaveChanges();
            return deletedPlayer;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return playerRepository.GetAllRoles().ToList();
        }

        public IEnumerable<PlayerDto> GetAll()
        {
            var result = playerRepository.GetAll();
            return mapper.Map<IEnumerable<PlayerDto>>(result);
        }

        public PlayerForUpdateDto GetById(int playerId)
        {
            var result = playerRepository.GetById(playerId);
            return mapper.Map<PlayerForUpdateDto>(result);
        }


    }
}
