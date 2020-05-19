using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TBoard.Entities;

namespace TBoard.Dto
{
    public class GameDto
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public ICollection<PlayerGameDto> PlayerGames{ get; set; }
    }
}
