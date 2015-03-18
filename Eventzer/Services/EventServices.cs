using Eventzer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventzer.Services
{
    public class EventServices
    {

        //returning all events in the database
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
        public List<Event> GetEventsFromCity(int zip)
        {
            var ctx = HttpContext.Current;
            List<Event> events = new List<Event>();
            string query = "SELECT * FROM eventzer.event e INNER JOIN eventzer.address a ON e.a_id=a.id AND a.city_zip=" + zip + ";";
            events = connectToDB(query);
            return events;
        }

        internal List<Event> GetEventsFromRegion(string region)
        {
            var ctx = HttpContext.Current;
            List<Event> events = new List<Event>();
            string query = "SELECT * FROM eventzer.event e INNER JOIN eventzer.address a ON e.a_id=a.id INNER JOIN eventzer.city c ON a.city_zip=c.zip WHERE c.region=" + region + ";";
            events = connectToDB(query);
            return events;
        }

        /* Getting a query that returns a list of events */
        public List<Event> connectToDB(string sql_query)
        {
            List<Event> events = new List<Event>();
            //connect string to the db
            string cs = @"server=localhost;userid=root;password=admin;database=eventzer";
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            try
            {
                //setting up both the connection and the command
                conn = new MySqlConnection(cs);
                conn.Open();
                string stm = sql_query;
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = stm;
                cmd.Prepare();
                rdr = cmd.ExecuteReader();
                DateTime start_time, end_time;
                while (rdr.Read())
                {
                    start_time = rdr.GetDateTime(2);
                    end_time = rdr.GetDateTime(3);
                    Event tmp_event = new Event(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(8), rdr.GetInt32(8), start_time, end_time, rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetString(6), rdr.GetBoolean(7));
                    events.Add(tmp_event);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                
            }
            return events;

        }
    }
}