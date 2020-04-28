using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.WebApi.Services.Interfaces;

namespace TBoard.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerGameController : ControllerBase
    {
        private readonly IPlayerGameService playerGameService;
        public PlayerGameController(IPlayerGameService playerGameService)
        {
            this.playerGameService = playerGameService;
        }

        //[HttpPost]
        //public ActionResult<PlayerGameDto> Post(PlayerGameDto playerGame)
        //{
        //    return Ok(playerGameService.Post(playerGame));
        //}
        
        [HttpPost]
        public ActionResult<PlayerGameDto[]> Post([FromBody]PlayerGameDto[] playerGames)
        {
            return Ok(playerGameService.PostAll(playerGames));
        }

    }
}
