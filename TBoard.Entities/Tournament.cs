using System;
using System.Collections.Generic;
using System.Text;

namespace TBoard.Entities
{
  public  class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
        public virtual ICollection<Game> Game { get; set; }
    }
}
