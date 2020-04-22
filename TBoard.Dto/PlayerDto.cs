using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TBoard.Dto
{
    public class PlayerDto
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gmail { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int? PlayerRole { get; set; }
    }
}
