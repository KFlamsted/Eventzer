using Eventzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eventzer.Controllers
{
    public class EventController : ApiController
    {
        List<Event> events = new List<Event>
        {
            new Event(1),
            new Event(2),
            new Event(3)
        };

        //returning all events created
        public IEnumerable<Event> GetAllEvents()
        {
            return events;
        }

        //finding the event with a specific id
        public IHttpActionResult GetEvent(int id)
        {
            var one_event = events.FirstOrDefault((p) => p.id == id);
            if (one_event == null)
            {
                return NotFound();
            }
            return Ok(one_event);
        }
   
    }
}
