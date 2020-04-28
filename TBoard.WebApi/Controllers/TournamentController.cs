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

        //[HttpGet()]
        //[HttpHead]
        //public ActionResult<IEnumerable<TournamentDto>> GetAll([FromQuery]TournamentResourceParameters tournamentResourceParameters)
        //{
        //    return Ok(tournamentService.GetAll(tournamentResourceParameters));
        //}

        [HttpGet]
        public ActionResult<object> GetAlll()
        {
            return Ok(tournamentService.GetTournamentWIthWinner());
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
        public void DeleteById(int tournamentId)
        {
          tournamentService.DeleteById(tournamentId);
        }

        [HttpPost]
        public ActionResult<Tournament> CreateTournament(TournamentDto tournament)
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
