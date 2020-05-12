using System.Collections.Generic;
using TBoard.Dto;
using TBoard.Entities.Auth;
using TBoard.WebApi.ResourceParameters;

namespace TBoard.WebApi.Services.Interfaces
{
    public interface IPlayerService
    {

        public IEnumerable<PlayerDto> GetAll(PlayerResourceParameters playerResourceParameters);
        public PlayerForUpdateDto GetById(int id);
        public void DeleteById(int id);
        public IEnumerable<Role> GetAllRoles();

        //Task<PaginatedResult<TDto>> GetPagedData(PagedRequest pagedRequest) where TEntity : IdentityUser<int>
        //                                                                                 where TDto : class;

    }
}
