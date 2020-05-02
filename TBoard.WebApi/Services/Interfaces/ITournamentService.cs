using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.WebApi.ResourceParameters;

namespace TBoard.WebApi.Services.Implementation
{
    public interface ITournamentService
    {

        public TournamentDto GetById(int id);
        public void DeleteById(int id);
        public TournamentDto AddTournament(TournamentDto entity);
        public object GetTournamentWithWinner(TournamentResourceParameters tournamentResourceParameters);
        public TournamentDto Update(TournamentDto entity);

    }
}
