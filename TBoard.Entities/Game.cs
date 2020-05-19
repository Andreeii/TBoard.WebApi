using System.Collections.Generic;

namespace TBoard.Entities
{
    public class Game:BaseEntity
    {
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        public virtual ICollection<PlayerGame> PlayerGames { get; set; }
    }
}
