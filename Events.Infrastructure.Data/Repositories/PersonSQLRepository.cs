using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Core.DomainService;
using Events.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Data.Repositories
{
    public class PersonSQLRepository : IPersonRepository
    {
        private readonly EventAppDBContext _ctx;

        public PersonSQLRepository(EventAppDBContext eventAppDBContext)
        {
            _ctx = eventAppDBContext;
        }

        public List<Person> GetAllPersons()
        {
            return _ctx.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _ctx.Persons.FirstOrDefault(person => person.Id == id);
        }

        public Person CreatePerson(Person person)
        {
            _ctx.Persons.Attach(person).State = EntityState.Added;
            _ctx.SaveChanges();
            return person;
        }

        public Person DeletePerson(int id)
        {
            var personToDelete = _ctx.Persons.Remove(new Person { Id = id });
            _ctx.SaveChanges();
            return personToDelete.Entity;
        }

        public Person UpdatePerson(Person personToUpdate)
        {
            _ctx.Persons.Attach(personToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return personToUpdate;
        }
    }
}
