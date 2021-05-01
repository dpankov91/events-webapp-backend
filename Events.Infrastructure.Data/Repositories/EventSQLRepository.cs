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
    public class EventSQLRepository : IEventRepository
    {
        private readonly EventAppDBContext _ctx;

        public EventSQLRepository(EventAppDBContext eventAppDBContext)
        {
            _ctx = eventAppDBContext;
        }

        public List<Event> GetAllEvents()
        {
            return _ctx.Events.ToList();
        }

        public Event GetEventById(int id)
        {
            return _ctx.Events
                .Include(ev => ev.Persons)
                 .Include(ev => ev.Companies)
                  .FirstOrDefault(ev => ev.Id == id);
        }

        public Event CreateEvent(Event ev)
        {
            _ctx.Events.Attach(ev).State = EntityState.Added;
            _ctx.SaveChanges();
            return ev;
        }

        public Event DeleteEvent(int id)
        {
            var eventToDelete = _ctx.Events.Remove(new Event { Id = id });
            _ctx.SaveChanges();
            return eventToDelete.Entity;
        }


        public Event UpdateEvent(Event eventToUpdate)
        {
            _ctx.Events.Attach(eventToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return eventToUpdate;
        }
    }
}
