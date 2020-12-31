using fleepage.oatleaf.com.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Commands.Dto
{
    public class StudentUserDto
    {
        [Required]
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirmation { get; set; }
    }
}
