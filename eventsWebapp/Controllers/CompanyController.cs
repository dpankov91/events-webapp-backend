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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            try
            {
                if (_companyService.GetAllCompanies() != null)
                {
                    return Ok(_companyService.GetAllCompanies());
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
        public ActionResult<Company> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Id must be bigger than 0");
                }
                return Ok(_companyService.GetCompanyById(id));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<CompanyController>
        [HttpPost]
        public ActionResult<Company> Post([FromBody] Company company)
        {
            try
            {
                return Ok(_companyService.CreateCompany(company));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public ActionResult<Company> Put(int id, [FromBody] Company company)
        {
            try
            {
                if (id < 1 || company.Id != id)
                {
                    return BadRequest("Enter correct id. ID must be bigger than 1");
                }
                return _companyService.UpdateCompany(company);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public ActionResult<Company> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Enter correct id. ID must be bigger than 1");
                }
                _companyService.DeleteCompany(id);
                return Ok("Company with id:" + id + " successfully deleted");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
