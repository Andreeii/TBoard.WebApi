using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.WebApi.ResourceParameters;
using TBoard.WebApi.Services.Implementation;

namespace TBoard.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService tournamentService;
        public TournamentController(ITournamentService tournamentService)
        {
            this.tournamentService = tournamentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetAll([FromQuery]TournamentResourceParameters tournamentResourceParameters)
        {
            //var tournament = new TournamentDto()
            //{
            //    Name = "Example2",
            //    Game = new List<GameDto>()
            //    {
            //        new GameDto
            //        {
            //            PlayerGame = new List<PlayerGameDto>()
            //            {
            //                new PlayerGameDto
            //                {
            //                    playerId = 1,
            //                    IsWinner =true
            //                },
            //                new PlayerGameDto
            //                {
            //                    playerId = 2,
            //                    IsWinner =false
            //                }
            //            }
            //        }
            //    }
            //};
            //var result = tournamentService.AddTournament(tournament);

            return Ok(tournamentService.GetTournamentWithWinner( tournamentResourceParameters));
        }

        [HttpGet("{tournamentId}")]
        public ActionResult<Tournament> GetById(int tournamentId)
        {
            if (tournamentService.GetById(tournamentId) == null)
            {
                return NotFound();
            }
            return Ok(tournamentService.GetById(tournamentId));
        }

        [HttpDelete("{tournamentId}")]
        public ActionResult<int> DeleteById(int tournamentId)
        {
          tournamentService.DeleteById(tournamentId);
            return Ok(tournamentId);
        }

        [HttpPost]
        public ActionResult<Tournament> Post(TournamentDto tournament)
        {
 
            return Ok(tournamentService.AddTournament(tournament));
        }

        [HttpPut("{tournamentId}")]
        public ActionResult<TournamentDto> UpdateTournament(TournamentDto tournament)
        {
            return Ok(tournamentService.Update(tournament));
        }

    }
}
