﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventzer.Models
{
    public class Address
    {

        public string address_line { get; set; }

        public City city { get; set; }

        public string region { get; set; }

        public string country { get; set; }

        public Address(string address_line, string city, int zipcode, string region, string country)
        {
            City temp_city = new City(city, zipcode);
            this.address_line = address_line;
            this.region = region;
            this.country = country;
        }
    }
}