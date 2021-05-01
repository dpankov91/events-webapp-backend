using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Core.Entites
{
    public class Company
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public int CompanyCode { get; set; }

        public bool isCash { get; set; }

        public string AdditionalInfo { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
