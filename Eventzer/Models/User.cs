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

        public User(int id)
        {
            this.id = id;
            this.email = "mail@mail.dk";
            this.first_name = "Peter";
            this.last_name = "Hansen";
            this.address = new Address("Kollegiebakken 9", "Kongens Lyngby", 2800, "Koebenhavn", "Denmark");
            this.password = "helloworld";
        }

        /* Constructor for user when setting all variables*/
        public User(int id, string email, string first_name, string last_name, Address address, string password)
        {
            this.id = id;
            this.email = email;
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.password = password;
        }

        //checking if two users are the same
        public bool equals(User user)
        {
            if(this.id == user.id)
            {
                return true;
            }

            return false;
        }

    }
}