using Eventzer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventzer.Models
{
    public class Event
    {
        public int id { get; set; }

        public string name { get; set; }

        public User owner { get; set; }

        public Address event_address { get; set; }

        public DateTime start_time { get; set; }

        public DateTime end_time { get; set; }

        public int price { get; set; }

        public int min_age { get; set; }

        public string description { get; set; }

        public bool public_event { get; set; }

        /* constructor setting all the variables in the object*/
        public Event(int id, string name, int owner, int event_address, DateTime start_time, DateTime end_time, int price, int min_age, string description, bool public_event)
        {
            this.id = id;
            this.name = name;
            var ctx = HttpContext.Current;
            if (ctx != null)
            {

                /* These have somehow to be dictionaies but this will do for now */
                // looking for the owner using the id
                foreach (User usr in (List<User>)ctx.Application["User"])
                {
                    if(usr.id == owner)
                    {
                        this.owner = usr;
                        break;
                    }
                }
                // looking for the address of the event
                foreach (Address add in (List<Address>)ctx.Application["Address"])
                {
                    if (add.id == event_address)
                    {
                        this.event_address = add;
                        break;
                    }

                }
            }
            this.start_time = start_time;
            this.end_time = end_time;
            this.price = price;
            this.min_age = min_age;
            this.description = description;
            this.public_event = public_event;
        }
    }
}