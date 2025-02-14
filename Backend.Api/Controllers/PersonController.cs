using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Context;
using Backend.Api.dto;
using Backend.Api.Models;
using Backend.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Controllers
{
    [Authorize]
    [Route("api/people")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePersonDto person)
        {
            Person newPerson = _personService.Create(person);
            return CreatedAtAction(nameof(FindOne), new { id = newPerson.Id }, newPerson);
        }

        [HttpGet("{id}")]
        public IActionResult FindOne([FromRoute] int id)
        {
            var person = _personService.FindOne(id);
            return Ok(person);
        }


        [HttpGet]
        public IActionResult FindAll()
        {
            var persons = _personService.FindAll();
            return Ok(persons);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdatePersonDto person)
        {
            var personUpdated = _personService.Update(id, person);
            return Ok(personUpdated);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            _personService.Remove(id);
            return NoContent();
        }

    }
}