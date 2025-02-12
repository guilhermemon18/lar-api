using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Models;
using Backend.Api.Utils.Validation;

namespace Backend.Api.dto
{
    public class UpdatePersonDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? Name { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        [CpfValidation]
        public string? Cpf { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }
        public bool IsActive { get; set; }
        public List<Phone>? Phones { get; set; }
    }
}