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

namespace TBoard.WebApi.Repositories.Implementation
{
    public class PlayerRepository : IPlayerRepository
    {
        protected readonly TournamentContext tournamentContext;
        private readonly IMapper mapper;

        public PlayerRepository(TournamentContext context,IMapper mapper)
        {
            tournamentContext = context;
            this.mapper = mapper;
        }

        public Player DeleteById(int id)
        {
            Player existing = tournamentContext.Players.Find(id);

            var player = tournamentContext.Players
             .Where(p => p.Id == id)
             .Include(player => player.PlayerGames)
             .FirstOrDefault();

            if(player.PlayerGames.Count == 0 )
            {
            tournamentContext.Players.Remove(existing);
            }
            else
            {
                throw  new Exception();
            }
            return existing;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return tournamentContext.Roles;
        }

        public IQueryable<Player> GetAll()
        {

            var allPlayers = tournamentContext.Players;
            return allPlayers;
        }

        public async Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : IdentityUser<int>
                                                                                                        where TDto : class
        {
            return await tournamentContext.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, mapper);
        }
        public Player GetById(int id)
        {
            return tournamentContext.Players.Find(id);
        }

        public void SaveChanges()
        {
            tournamentContext.SaveChanges();
        }
    }
}
