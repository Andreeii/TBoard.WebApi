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
    [Route("tournaments")]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService tournamentService;
        private readonly IMapper mapper;
        public TournamentController(ITournamentService tournamentService, IMapper mapper)
        {
            this.tournamentService = tournamentService;
            this.mapper = mapper;
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<TournamentDto>> GetAll([FromQuery]TournamentResourceParameters tournamentResourceParameters)
        {
            //throw new Exception("Test Exception");
            var result = tournamentService.GetAll(tournamentResourceParameters);
            return Ok(mapper.Map<IEnumerable<TournamentDto>>(result));
        }

        [HttpGet("{tournamentId}")]
        public ActionResult<Tournament> GetById(int tournamentId)
        {
            var result = tournamentService.GetById(tournamentId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TournamentDto>(result));
        }

        [HttpDelete("{tournamentId}")]
        public void DeleteById(int tournamentId)
        {
            tournamentService.DeleteById(tournamentId);
            tournamentService.SaveChanges();
        }

        [HttpPost]
        public ActionResult<TournamentDto> CreateTournament(TournamentForCreationDto tournament)
        {

            var tournamentEntity = mapper.Map<Tournament>(tournament);
            tournamentService.AddTournament(tournamentEntity);
            tournamentService.SaveChanges();
            var tournamentToReturn = mapper.Map<Tournament>(tournamentEntity);
            return Ok(tournamentToReturn);

        }

        [HttpPut("{tournamentId}")]
        public ActionResult UpdateTournament(TournamentDto tournament)
        {
            var tournamentEntity = mapper.Map<Tournament>(tournament);
            tournamentService.Update(tournamentEntity);
            tournamentService.SaveChanges();
            var tournamentToReturn = mapper.Map<Tournament>(tournamentEntity);
            return Ok(tournamentToReturn);
        }

    }
}
