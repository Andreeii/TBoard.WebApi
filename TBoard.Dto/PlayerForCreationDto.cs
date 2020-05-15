using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

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

        public string ProfileImage { get; set; }

    }
}
