using Eventzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventzer.Services
{
    public class EventServices
    {

        public List<Event> GetAllEvents()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                return (List<Event>)ctx.Application["Events"];
            }
            return new List<Event>();
        }


        //method getting all events from a specific city
        public List<Event> GetEventsFromCity(string cityname, int zip)
        {
            var ctx = HttpContext.Current;
            List<Event> events = new List<Event>();
            if (ctx != null)
            {
                foreach(Event e in (List<Event>)ctx.Application["Events"])
                {
                    //checking if cityname and zipcode is the same
                    if(e.event_address.city.name.Equals(cityname) && e.event_address.city.zipcode == zip)
                    {
                        events.Add(e);
                    }
                }
            }
            return events;
        }

        internal List<Event> GetEventsFromRegion(string region)
        {
            var ctx = HttpContext.Current;
            List<Event> events = new List<Event>();
            if (ctx != null)
            {
                foreach (Event e in (List<Event>)ctx.Application["Events"])
                {
                    //checking if cityname and zipcode is the same
                    if (e.event_address.region.Equals(region))
                    {
                        events.Add(e);
                    }
                }
            }
            return events;
        }
    }
}