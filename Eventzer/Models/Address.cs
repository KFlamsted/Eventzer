using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventzer.Models
{
    public class Address
    {
        public int id { get; set; }

        public string address_line { get; set; }

        public City city { get; set; }

        public string country { get; set; }

        public Address(int id, string address_line, string city, int zipcode, string region, string country)
        {
            this.id = id;
            this.city = new City(zipcode, city, region);
            this.address_line = address_line;
            this.country = country;
        }
    }
}