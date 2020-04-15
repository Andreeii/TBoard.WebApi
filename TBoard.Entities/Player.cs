using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TBoard.Entities
{
  public  class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gmail { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int? PlayerRole { get; set; }

        public virtual PlayerRole PlayerRoleNavigation { get; set; }
        public virtual ICollection<PlayerGame> PlayerGame { get; set; }
    }
}
