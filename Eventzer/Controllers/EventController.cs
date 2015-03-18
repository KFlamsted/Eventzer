using Eventzer.Models;
using Eventzer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Eventzer.Controllers
{
    public class EventController : ApiController
    {
        private EventServices es = new EventServices();

        //returning all events created
        public List<Event> GetAllEvents()
        {
            return es.GetAllEvents();
        }

        //finding the event with a specific id
        public IHttpActionResult GetEvent(int id)
        {
            List<Event> events = es.GetAllEvents();
            var one_event = events.FirstOrDefault((p) => p.id == id);
            if (one_event == null)
            {
                return NotFound();
            }
            return Ok(one_event);
        }

        //getting events from a given city
        public List<Event> Get([FromUri] int zip)
        {
            return es.GetEventsFromCity(zip);
        }

        //getting events from a given region
        public List<Event> Get([FromUri] string region)
        {
            return es.GetEventsFromRegion(region);
        }


    }
}
