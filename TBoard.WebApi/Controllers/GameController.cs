using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.WebApi.Services.Interfaces;

namespace TBoard.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {

        private readonly IGameService gameService;
        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<GameDto>> GetAll(int tournamentId)
        {
            if (!gameService.TournamentExists(tournamentId))
            {
                return NotFound();
            }
            var result = gameService.GetByTournamentId(tournamentId);
            return Ok(result);
        }

        [HttpGet("{gameId}")]
        public IActionResult GetById(int GameId)
        {
            var result = gameService.GetById(GameId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{gameId}")]
        public ActionResult DeleteById(int GameId)
        {

            if (!gameService.GameExists(GameId))
            {
                return NotFound();
            }
            else
            {
                gameService.DeleteById(GameId);
                return Ok();
            }
        }

        //[HttpPost]
        //public ActionResult<GameDto> CreateGameForTournament(GameForCreationDto game)
        //{
        //    if (!gameService.TournamentExists(game.TournamentId))
        //    {
        //        return NotFound();
        //    }
        //    return gameService.Post(game);
        //}

        [HttpPost]
        public ActionResult<GameDto> Post(GameDto game)
        {
            return gameService.Post(game);
        }
    }
}
