using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Core.ApplicationService.Services;
using Events.Core.DomainService;
using Events.Core.Entites;

namespace Events.Core.ApplicationService.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepo = personRepository;
        }

        public List<Person> GetAllPersons()
        {
            return _personRepo.GetAllPersons();
        }

        public Person GetPersonById(int id)
        {
            return _personRepo.GetPersonById(id);
        }

        public Person CreatePerson(Person person)
        {
            return _personRepo.CreatePerson(person);
        }

        public Person DeletePerson(int id)
        {
            return _personRepo.DeletePerson(id);
        }

        public Person UpdatePerson(Person personToUpdate)
        {
            return _personRepo.UpdatePerson(personToUpdate);
        }
    }
}
