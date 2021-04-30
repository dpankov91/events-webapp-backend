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

        public string AdditionalInfo { get; set; }

        public int? PersonId { get; set; }
        public Person Person { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
