using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TBoard.Dto
{
    public class PlayerDto
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        //public string Name { get; set; }

        //[Required]
        //public string Surname { get; set; }

        [Required]
        public string UserName { get; set; }

        //public string Password { get; set; }

        //[Required]
        //public string Email { get; set; }
        //public DateTime RegistrationDate { get; set; }
    }
}
