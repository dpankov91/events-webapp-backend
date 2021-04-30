using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Data
{
    public class EventAppDBContext : DbContext
    {
        public EventAppDBContext(DbContextOptions<EventAppDBContext> opt)
                    : base(opt) { }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Person> Persons { get; set; }
    }
}
