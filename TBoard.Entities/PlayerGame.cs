using System;
using System.Collections.Generic;
using System.Text;

namespace TBoard.Entities
{
   public class PlayerGame:BaseEntity
    {
        public int? PlayerId { get; set; }
        public int GameId { get; set; }
        public bool? IsWinner { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
