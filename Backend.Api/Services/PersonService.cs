using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.dto;
using Backend.Api.Models;
using Backend.Api.Repositories;
using Backend.Api.Utils.Errors.Types;

namespace Backend.Api.Services
{
    public class PersonService
    {
        private readonly PersonRepository _repository;

        public PersonService(PersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(CreatePersonDto person)
        {
            var phones = new List<Phone>();
            // Mapeia PhonesDto para Phone usando LINQ
            if (person.Phones != null)
            {
                phones = person.Phones.Select(dto => new Phone(dto.PhoneType, dto.Number)).ToList();

            }
            Person newPerson = new Person(person.Name, person.Cpf, person.BirthDate, person.IsActive, phones);
            _repository.Add(newPerson);
            return newPerson;
        }

        public Person FindOne(int id)
        {
            var person = _repository.FindById(id) ?? throw new NotFoundException("Person not found");
            return person;
        }


        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Update(int id, UpdatePersonDto person)
        {
            Person? personToUpdate = _repository.FindById(id) ?? throw new NotFoundException("Person not found");
            personToUpdate.Name = person.Name;
            personToUpdate.IsActive = person.IsActive;
            personToUpdate.BirthDate = person.BirthDate;
            personToUpdate.Cpf = person.Cpf;
            personToUpdate.Phones = person.Phones;

            _repository.Update(personToUpdate);

            return personToUpdate;
        }

        public void Remove(int id)
        {
            Person? personToRemove = _repository.FindById(id) ?? throw new NotFoundException("Person not found");
            _repository.Remove(personToRemove);
        }
    }
}