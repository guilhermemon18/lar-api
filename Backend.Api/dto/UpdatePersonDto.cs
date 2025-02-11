using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Models;

namespace Backend.Api.dto
{
    public class UpdatePersonDto
    {
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public List<Phone>? Phones { get; set; }
    }
}