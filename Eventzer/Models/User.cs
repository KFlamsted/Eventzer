using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventzer.Models
{
    public class User
    {
        public int id { get; set; }

        public string email { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public Address address { get; set; }

        public string password { get; set; }
    }
}