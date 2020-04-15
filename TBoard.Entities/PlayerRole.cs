using System;
using System.Collections.Generic;
using System.Text;

namespace TBoard.Entities
{
   public class PlayerRole
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Player> Player { get; set; }
    }
}
