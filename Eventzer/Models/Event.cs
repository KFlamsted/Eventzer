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

        public Event(int id)
        {
            this.id = id;
            this.name = "asti night";
            this.owner = new User();
            this.event_address = owner.address;
            this.start_time = DateTime.Now;
            this.end_time = DateTime.Now;
            this.price = 0;
            this.min_age = 18;
            this.description = "Kom til Asti night og drik en masse Asti!";
            this.public_event = true;
        }

    }
}