using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Utils.Enums;

namespace Backend.Api.Models
{
    public class Phone
    {

        public Phone(PhoneType phoneType, string number, int personId)
        {
            PhoneType = phoneType;
            Number = number;
            PersonId = personId;
        }
        public int Id { get; set; }
        public PhoneType PhoneType { get; set; }
        public string Number { get; set; }
        public int PersonId { get; set; }
    }
}