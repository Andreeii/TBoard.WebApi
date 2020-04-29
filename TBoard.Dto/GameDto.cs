using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBoard.Dto
{
    public class GameDto
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
    }
}
