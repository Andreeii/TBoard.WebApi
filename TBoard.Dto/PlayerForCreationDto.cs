using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TBoard.Dto
{
    public class PlayerForCreationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int? PlayerRole { get; set; }
    }
}
