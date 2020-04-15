using System;
using System.Collections.Generic;
using System.Text;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Repository.ResourceParameters;

namespace TBoard.Services
{
    public interface ITournamentService
    {

        public IEnumerable<TournamentDto> GetAll(TournamentResourceParameters tournamentResourceParameters);
        public TournamentDto GetById(int id);
        public void DeleteById(int id);
        public Tournament AddTournament(TournamentForCreationDto entity);
        public TournamentDto Update(TournamentDto entity);

    }
}
