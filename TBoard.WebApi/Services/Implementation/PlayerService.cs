using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Entities.Auth;
using TBoard.Infrastructure.Models;
using TBoard.WebApi.Extensions;
using TBoard.WebApi.Repositories.Interfaces;
using TBoard.WebApi.ResourceParameters;
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

        public PlayerForUpdateDto GetById(int playerId)
        {
            var result = playerRepository.GetById(playerId);
            return mapper.Map<PlayerForUpdateDto>(result);
        }

        //public async Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(this IService service, PagedRequest pagedRequest) where TEntity : IdentityUser<int>
        //                                                                                                                       where TDto : class
        //{
        //    return await playerRepository.GetAll().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, mapper);
        //}

    }
}
