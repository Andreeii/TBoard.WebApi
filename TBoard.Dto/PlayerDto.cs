using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TBoard.Dto
{
    public class PlayerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string ProfileImage { get; set; }
    }
}
