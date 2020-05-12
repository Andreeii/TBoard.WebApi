using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;
using TBoard.Entities.Auth;
using TBoard.Infrastructure.Models;
using TBoard.WebApi.Extensions;
using TBoard.WebApi.Repositories.Interfaces;
using TBoard.WebApi.ResourceParameters;

namespace TBoard.WebApi.Repositories.Implementation
{
    public class PlayerRepository : IPlayerRepository
    {
        protected readonly TournamentContext tournamentContext;
        private readonly IMapper mapper;


        protected DbSet<Player> playerTable;
        protected DbSet<Role> rolesTable;

        public PlayerRepository(TournamentContext context,IMapper mapper)
        {
            tournamentContext = context;
            playerTable = context.Set<Player>();
            rolesTable = context.Set<Role>();
            this.mapper = mapper;
        }

        public void DeleteById(int id)
        {
            Player existing = playerTable.Find(id);
            playerTable.Remove(existing);
        }

        public IQueryable<Player> GetAll()
        {
            return playerTable;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return rolesTable;
        }

        public IEnumerable<Player> GetAll(PlayerResourceParameters playerResourceParameters)
        {
            var collection = tournamentContext.Player as IQueryable<Player>;
            if (playerResourceParameters == null)
            {
                return GetAll();
            }
            else if (!string.IsNullOrWhiteSpace(playerResourceParameters.SearchQuery))
            {
                var searchQuery = playerResourceParameters.SearchQuery.Trim();
                collection = collection
                    .Where(a => a.UserName.Contains(searchQuery));
            }
            return collection.ToList();
        }

        public async Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : IdentityUser<int>
                                                                                                        where TDto : class
        {
            return await tournamentContext.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, mapper);
        }
        public Player GetById(int id)
        {
            return playerTable.Find(id);
        }

        public void SaveChanges()
        {
            tournamentContext.SaveChanges();
        }
    }
}
