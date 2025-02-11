using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Context;
using Backend.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PersonController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            // return Ok(contato);
            return CreatedAtAction(nameof(FindOne), new { id = person.Id }, person);
        }

        [HttpGet("{id}")]
        public IActionResult FindOne(int id)
        {
            var person = _context.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }


        [HttpGet]
        public IActionResult FindAll()
        {
            var person = _context.People.ToList();
            return Ok(person);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Person person)
        {
            var personDataBase = _context.People.Find(id);
            if (personDataBase == null)
            {
                return NotFound();
            }
            personDataBase.Name = person.Name;
            personDataBase.IsActive = person.IsActive;
            personDataBase.BirthDate = person.BirthDate;
            personDataBase.Cpf = person.Cpf;

            _context.People.Update(personDataBase);
            _context.SaveChanges();

            return Ok(personDataBase);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var personDataBase = _context.People.Find(id);
            if (personDataBase == null)
            {
                return NotFound();
            }
            _context.People.Remove(personDataBase);
            _context.SaveChanges();
            return NoContent();
        }

    }
}