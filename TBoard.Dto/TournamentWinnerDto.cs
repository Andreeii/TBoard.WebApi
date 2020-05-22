namespace TBoard.Dto
{
    public class TournamentWinnerDto
    {
        public int TournamentId { get; set; }

        public int NumberOfWins { get; set; }

        public string WinnerName { get; set; }

        public string TournamentName { get; set; }
    }
}
