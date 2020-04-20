using System;
using System.Collections.Generic;
using System.Text;

namespace TBoard.Dto
{
   public class TournamentDto
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
