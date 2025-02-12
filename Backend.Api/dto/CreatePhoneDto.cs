using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Utils.Enums;

namespace Backend.Api.dto
{
    public class CreatePhoneDto
    {
        public PhoneType PhoneType { get; set; }
        public string Number { get; set; }

    }
}