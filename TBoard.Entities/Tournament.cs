using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBoard.Entities
{
  public  class Tournament
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int TournamentId { get; set; }
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
        public virtual ICollection<Game> Game { get; set; }
    }
}
