using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBoard.Entities
{
  public  class Tournament:BaseEntity
    {
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
        public virtual ICollection<Game> Game { get; set; }
    }
}
