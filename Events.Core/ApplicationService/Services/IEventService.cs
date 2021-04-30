﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Core.Entites;

namespace Events.Core.ApplicationService.Services
{
    public interface IEventService
    {
        List<Event> GetAllEvents();

        Event GetEventById(int id);

        Event CreateEvent(Event ev);

        Event DeleteEvent(int id);

        Event UpdateEvent(Event eventToUpdate);
    }
}
