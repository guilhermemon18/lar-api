using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Api.dto
{
    public class TokenDto
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Token { get; set; }
    }
}