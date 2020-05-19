using System;
using System.Collections.Generic;
using TBoard.Entities;

namespace TBoard.Dto
{
   public class TournamentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<GameDto> Games { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
