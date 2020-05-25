using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;
using TBoard.Entities.Auth;
using TBoard.Infrastructure.Models;

namespace TBoard.WebApi.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Player GetById(int id);

        IEnumerable<Role> GetAllRoles();

        Player DeleteById(int id);

        IQueryable<Player> GetAll();

        Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : IdentityUser<int>
                                                                                           where TDto : class;
        void SaveChanges();
    }
}
