using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TBoard.Entities
{
   public class Game:BaseEntity
    {
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        public virtual ICollection<PlayerGame> PlayerGame { get; set; }
    }
}
