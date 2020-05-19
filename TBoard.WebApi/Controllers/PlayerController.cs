using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Entities.Auth;
using TBoard.Infrastructure.Models;
using TBoard.WebApi.Repositories.Interfaces;
using TBoard.WebApi.Services.Interfaces;
using AllowAnonymousAttribute = Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute;


namespace TBoard.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerService playerService;
        private readonly IPlayerRepository playerRepository;

        public PlayerController(IPlayerService playerService, IPlayerRepository playerRepository)
        {
            this.playerService = playerService;
            this.playerRepository = playerRepository;
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<PlayerDto>> GetAll()
        {
            return Ok(playerService.GetAll());
        }

        [HttpGet("byId")]
        public ActionResult<PlayerForUpdateDto> GetById()
        {
            var playerId = User.Identity.GetUserId();
            return Ok(playerService.GetById(Int32.Parse(playerId)));
        }


        [HttpGet("{playerId}")]
        public ActionResult<PlayerForUpdateDto> GetPlayerById(int playerId)
        {
            return Ok(playerService.GetById(playerId));
        }

        [HttpDelete("{playerId}")]
        public ActionResult<Player> DeleteById(int playerId)
        {
            return Ok(playerService.DeleteById(playerId));
        }

        [HttpPost("checkUserName")]
        public ActionResult<bool>CheckUserName(string checkUserName)
        {
            return Ok(playerRepository.CheckUserName(checkUserName));
        }


        [AllowAnonymous]
        [HttpGet("roles")]
        public ActionResult<Role> GetRoles()
        {
            return Ok(playerService.GetAllRoles());
        }

        [HttpPost("paginatedSearch")]
        public async Task<IActionResult> GetPagedBooks([FromBody]PagedRequest pagedRequest)
        {
            var pagedPlayerDto = await playerRepository.GetPagedData<Player, PlayerDto>(pagedRequest);
            return Ok(pagedPlayerDto);
        }

    }
}
