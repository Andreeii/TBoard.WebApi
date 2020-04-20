using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Services;

namespace TBoard.WebApi.Controllers
{
    [ApiController]
    [Route("api/tournament/{tournamentId}/[controller]")]
    public class GameController : ControllerBase
    {

        private readonly IGameService gameService;
        private readonly IMapper mapper;
        public GameController(IGameService gameService, IMapper mapper)
        {
            this.gameService = gameService;
            this.mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<GameDto>> GetAll(int tournamentId)
        {
            if (!gameService.Exists(tournamentId))
            {
                return NotFound();
            }
            var result = gameService.GetByTournamentId(tournamentId);
            return Ok(mapper.Map<IEnumerable<GameDto>>(result));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = gameService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<GameDto>(result));
        }

        [HttpDelete("{id}")]
        public void DeleteById(int id)
        {
            gameService.DeleteById(id);
        }

        [HttpPost]
        public ActionResult<GameDto> CreateGameForTournament(int tournamnetId, GameForCreationDto game)
        {
            if (!gameService.Exists(tournamnetId))
            {
                return NotFound();
            }
            var gameEntity = mapper.Map<Game>(game);
            gameService.Post(gameEntity);
            gameService.SaveChanges();

            var gameToReturn = mapper.Map<GameDto>(gameEntity);

            return gameToReturn;
        }
    }
}
