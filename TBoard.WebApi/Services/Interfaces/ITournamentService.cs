using System.Collections.Generic;
using TBoard.Dto;

namespace TBoard.WebApi.Services.Implementation
{
    public interface ITournamentService
    {

        public TournamentDto GetById(int id);
        public void DeleteById(int id);
        public TournamentDto AddTournament(TournamentDto entity);
        public ICollection<TournamentWinnerDto> GetTournamentWithWinner();
        public TournamentDto Update(TournamentDto entity);
        public ICollection<TournamentsParticipation> GetPlayerTournaments(int playerId);

        public IList<int> GetProgress();



    }
}
