
using System.ComponentModel.DataAnnotations;

namespace Backend.Api.Models
{
        public class Person
        {

                public Person() { }
                public Person(string name, string cpf, DateOnly? birthDate, bool? isActive, List<Phone> phones)
                {
                        Name = name;
                        Cpf = cpf;
                        BirthDate = birthDate;
                        IsActive = isActive;
                        Phones = phones;
                }

                public int Id { get; set; }
                public string? Name { get; set; }
                public string? Cpf { get; set; }
                public DateOnly? BirthDate { get; set; }
                public bool? IsActive { get; set; }
                public List<Phone>? Phones { get; set; }
        }
}