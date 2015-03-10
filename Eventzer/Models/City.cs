using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventzer.Models
{
    public class City
    {
        public string name { get; set; }

        public int zipcode { get; set; }

        public string region { get; set; }

        public City(string name, int zipcode, string region)
        {
            this.name = name;
            this.zipcode = zipcode;
            this.region = region;
        }
    }
}