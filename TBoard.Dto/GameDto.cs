using System.Collections.Generic;

namespace TBoard.Dto
{
    public class GameDto
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public ICollection<PlayerGameDto> PlayerGames{ get; set; }
    }
}
