using System;
using System.Collections.Generic;

namespace TBoard.Entities
{
    public  class Tournament:BaseEntity
    {
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
