using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Core.Entites
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int IdNumber { get; set; }

        public bool isCash { get; set; }

        public string AdditionalInfo { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
