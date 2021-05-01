using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Core.Entites
{
    public class Event
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public string Place { get; set; }

        public string AdditionalInfo { get; set; }

        public ICollection<Person> Persons { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
