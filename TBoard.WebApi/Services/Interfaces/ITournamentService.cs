using TBoard.Dto;

namespace TBoard.WebApi.Services.Implementation
{
    public interface ITournamentService
    {

        public TournamentDto GetById(int id);
        public void DeleteById(int id);
        public TournamentDto AddTournament(TournamentDto entity);
        public object GetTournamentWithWinner();
        public TournamentDto Update(TournamentDto entity);
        public object GetWinnedTournaments(int playerId);


    }
}
