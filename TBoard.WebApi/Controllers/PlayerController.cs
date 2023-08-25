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
            var players = playerService.GetAll();
            return Ok(players);
        }

        [HttpGet("playerAccount")]
        public ActionResult<PlayerForUpdateDto> GetById()
        {
            var playerId = User.Identity.GetUserId();
            var player = playerService.GetById(Int32.Parse(playerId));
            return Ok(player);
        }

        [HttpGet("{playerId}")]
        public ActionResult<PlayerForUpdateDto> GetPlayerById(int playerId)
        {
            return Ok(playerService.GetById(playerId));
        }

        [HttpDelete("{playerId}")]
        public ActionResult<Player> DeleteById(int playerId)
        {
            try
            {
                Player player = playerService.DeleteById(playerId);
                return Ok(player);
            }
            catch
            {
                return StatusCode(400, "This player can't be deleted because he is engaged in another tournament !");
            }
        }

        [AllowAnonymous]
        [HttpGet("roles")]
        public ActionResult<Role> GetRoles()
        {
            return Ok(playerService.GetAllRoles());
        }

        [HttpPost("paginatedSearch")]
        public async Task<IActionResult> GetPagedPlayers([FromBody] PagedRequest pagedRequest)
        {
            var pagedPlayerDto = await playerRepository.GetPagedData<Player, PlayerDto>(pagedRequest);
            return Ok(pagedPlayerDto);
        }
    }
}