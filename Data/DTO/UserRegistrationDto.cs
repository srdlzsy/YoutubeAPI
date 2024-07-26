using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class UserRegistrationDto
    {
        [Required]
        public string Email { get; set; }=string.Empty;

        [Required]
        public string Password { get; set; }= string.Empty;
        [Required]
        public string ConfirmPassword { get; set; }=string.Empty;
    }
}
