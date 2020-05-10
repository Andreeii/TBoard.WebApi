using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TBoard.Dto
{
    public class ChangePasswordDto
    {
        [Required]
        public string CurentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
