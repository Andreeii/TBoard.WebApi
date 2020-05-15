
using System;
using System.Collections.Generic;
using System.Text;

namespace TBoard.Dto
{
   public class PlayerGameDto
    {
        public int Id { get; set; }
        public  int gameId { get; set; }
        public  int playerId { get; set; }
        public bool? IsWinner { get; set; }
    }
}
