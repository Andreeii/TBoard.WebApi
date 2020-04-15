using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Repository.ResourceParameters;
using TBoard.Services;

namespace TBoard.WebApi.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<PlayerDto>> GetAll([FromQuery]PlayerResourceParameters playerResourceParameters)
        {
            return Ok(playerService.GetAll(playerResourceParameters));
        }

        [HttpGet("{playerId}")]
        public ActionResult<Tournament> GetById(int playerId)
        {
            if (playerService.GetById(playerId) == null)
            {
                return NotFound();
            }
            return Ok(playerService.GetById(playerId));
        }

        [HttpPost]
        public ActionResult<Tournament> CreatePlayer(PlayerDto player)
        {
            return Ok(playerService.AddPlayer(player));

        }

        [HttpDelete("{playerId}")]
        public void DeleteById(int playerId)
        {
            playerService.DeleteById(playerId);
        }

        [HttpPut("{playerId}")]
        public ActionResult<TournamentDto> UpdatePlayer(PlayerDto player)
        {
            return Ok(playerService.Update(player));
        }
    }
}
