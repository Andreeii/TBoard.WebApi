using System;
using System.Collections.Generic;
using System.Text;

namespace TBoard.Dto
{
   public class PlayerGameDto
    {
        public int? PlayerId { get; set; }
        public int GameId { get; set; }
        public bool? IsWinner { get; set; }
    }
}
