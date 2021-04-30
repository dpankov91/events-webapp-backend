using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Core.Entites;

namespace Events.Core.ApplicationService.Services
{
    public interface IPersonService
    {
        List<Person> GetAllPersons();

        Person GetPersonById(int id);

        Person CreatePerson(Person person);

        Person DeletePerson(int id);

        Person UpdatePerson(Person personToUpdate);
    }
}
