
using System.ComponentModel.DataAnnotations;

namespace Backend.Api.Models
{
    public class Person
    {

        public Person() { }
<<<<<<< HEAD
        public Person(string name, string cpf, DateOnly birthDate, bool isActive, List<Phone> phones)
=======
        public Person(string name, string cpf, DateOnly? birthDate, bool? isActive, List<Phone> phones)
>>>>>>> feature/modelsValidation
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
<<<<<<< HEAD
        public DateOnly BirthDate { get; set; }
        public bool IsActive { get; set; }
=======
        public DateOnly? BirthDate { get; set; }
        public bool? IsActive { get; set; }
>>>>>>> feature/modelsValidation
        public List<Phone>? Phones { get; set; }
    }
}