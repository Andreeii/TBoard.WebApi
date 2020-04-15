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

        private readonly IPlayerService playerService = null;
        private readonly IMapper mapper;

        public PlayerController(IPlayerService pserv, IMapper mapper)
        {
            this.playerService = pserv;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]PlayerResourceParameters playerResourceParameters)
        {
            var result = playerService.GetAll(playerResourceParameters);
            return Ok(mapper.Map<IEnumerable<PlayerDto>>(result));
        }

        [HttpGet("{playerId}")]
        public ActionResult<Player> GetById(int playerId)
        {
            var result = playerService.GetById(playerId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PlayerDto>(result));
        }

        [HttpDelete("{id}")]
        public void DeleteById(int id)
        {
            playerService.DeleteById(id);
        }

        [HttpPost]
        public void Post(Player entity)
        {
            playerService.Post(entity);
        }
    }
}
