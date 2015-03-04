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

        public int age { get; set; }

        public string description { get; set; }

        public bool public_event { get; set; }

    }
}