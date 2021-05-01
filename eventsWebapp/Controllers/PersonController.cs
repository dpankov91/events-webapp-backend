using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Core.ApplicationService.Services;
using Events.Core.Entites;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eventsWebapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            try
            {
                if (_personService.GetAllPersons() != null)
                {
                    return Ok(_personService.GetAllPersons());
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Id must be bigger than 0");
                }
                return Ok(_personService.GetPersonById(id));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<CompanyController>
        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person person)
        {
            try
            {
                return Ok(_personService.CreatePerson(person));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, [FromBody] Person person)
        {
            try
            {
                if (id < 1 || person.Id != id)
                {
                    return BadRequest("Enter correct id. ID must be bigger than 1");
                }
                return _personService.UpdatePerson(person);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Enter correct id. ID must be bigger than 1");
                }
                _personService.DeletePerson(id);
                return Ok("Person with id:" + id + " successfully deleted");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
