using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Utils.Enums;

namespace Backend.Api.dto
{
    public class CreatePhoneDto
    {
        [Required]
        [Range(0, 2)]
        public PhoneType PhoneType { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(14)]
        public string Number { get; set; }

    }
}