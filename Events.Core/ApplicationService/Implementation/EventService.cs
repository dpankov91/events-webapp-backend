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
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepo;

        public EventService(IEventRepository eventRepository)
        {
            if (eventRepository == null)
            {
                throw new NullReferenceException();
            }
            _eventRepo = eventRepository;
        }
        public List<Event> GetAllEvents()
        {
            return _eventRepo.GetAllEvents();
        }

        public Event GetEventById(int id)
        {
            return _eventRepo.GetEventById(id);
        }

        public Event CreateEvent(Event ev)
        {
            return _eventRepo.CreateEvent(ev);
        }

        public Event DeleteEvent(int id)
        {
            return _eventRepo.DeleteEvent(id);
        }

        public Event UpdateEvent(Event eventToUpdate)
        {
            return _eventRepo.UpdateEvent(eventToUpdate);
        }
    }
}
