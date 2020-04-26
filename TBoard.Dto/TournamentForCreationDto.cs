using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TBoard.Dto
{
    public class TournamentForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

    }
}
