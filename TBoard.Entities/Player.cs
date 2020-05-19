using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TBoard.Entities
{
  public  class Player:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string ProfileImage { get; set; }
        public virtual ICollection<PlayerGame> PlayerGames { get; set; }
    }
}
