using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TBoard.Dto;
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
        public ActionResult<IEnumerable<TournamentWinnerDto>> GetTournamentWithWinner()
        {
            return Ok(tournamentService.GetTournamentWithWinner());
        }

        [HttpGet("participationTournaments")]
        public ActionResult<IEnumerable<object>> GetWinnedTournaments()
        {
            var playerId = User.Identity.GetUserId();

            return Ok(tournamentService.GetPlayerTournaments(Int32.Parse(playerId)));
        }

        [HttpGet("{tournamentId}")]
        public IActionResult GetById(int tournamentId)
        {
            if (tournamentService.GetById(tournamentId) == null)
            {
                return NotFound();
            }
            return Ok(tournamentService.GetById(tournamentId));
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{tournamentId}")]
        public ActionResult<int> DeleteById(int tournamentId)
        {
          tournamentService.DeleteById(tournamentId);
            return Ok(tournamentId);
        }

        [HttpPost]
        public IActionResult Post(TournamentDto tournament)
        {
            return Ok(tournamentService.AddTournament(tournament));
           
        }

        [HttpPut]
        public ActionResult<TournamentDto> UpdateTournament(TournamentDto tournament)
        {
            return Ok(tournamentService.Update(tournament));
        }


        [HttpGet("progress")]
        public IActionResult GetProgress()
        {
          return  Ok( tournamentService.GetProgress());

        }

    }
}
