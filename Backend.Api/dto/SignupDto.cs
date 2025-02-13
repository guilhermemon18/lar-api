using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Api.dto
{
    public class SignupDto
    {
        [Required]
        [MinLength(2)]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(4)]
        public string? Password { get; set; }
        [Required]

        public bool IsAdmin { get; set; }

    }
}