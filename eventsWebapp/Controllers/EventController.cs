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
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public ActionResult<IEnumerable<Event>> Get()
        {
            try
            {
                if (_eventService.GetAllEvents() != null)
                {
                    return Ok(_eventService.GetAllEvents());
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
        public ActionResult<Event> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Id must be bigger than 0");
                }
                return Ok(_eventService.GetEventById(id));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<CompanyController>
        [HttpPost]
        public ActionResult<Event> Post([FromBody] Event ev)
        {
            try
            {
                return Ok(_eventService.CreateEvent(ev));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public ActionResult<Event> Put(int id, [FromBody] Event ev)
        {
            try
            {
                if (id < 1 || ev.Id != id)
                {
                    return BadRequest("Enter correct id. ID must be bigger than 1");
                }
                return _eventService.UpdateEvent(ev);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public ActionResult<Event> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Enter correct id. ID must be bigger than 1");
                }
                _eventService.DeleteEvent(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
