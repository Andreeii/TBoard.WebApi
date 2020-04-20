using System;
using System.Collections.Generic;
using System.Text;

namespace TBoard.Entities
{
   public class Game
    {
        public int GameId { get; set; }
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        public virtual ICollection<PlayerGame> PlayerGame { get; set; }
    }
}
