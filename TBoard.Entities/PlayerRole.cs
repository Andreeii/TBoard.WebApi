using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TBoard.Entities
{
   public class PlayerRole
    {
        [Key]
        public int RoleId { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Player> Player { get; set; }
    }
}
