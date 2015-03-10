using Eventzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Eventzer
{

    public class WebApiApplication : System.Web.HttpApplication
    {
        Dictionary<int, Event> events = new Dictionary<int, Event>();
        Dictionary<int, City> cities = new Dictionary<int, City>();
        bool first_start = false;
        
        protected void Application_Start()
        {
            //loading in some test data on application startup
            if(!first_start)
            {
                string cs = @"server=localhost;userid=root;password=admin;database=eventzer";
                MySqlConnection conn = null;
                MySqlDataReader rdr = null;

                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    string stm = "SELECT * FROM eventzer.city";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    rdr = cmd.ExecuteReader();
                    int zip = 0;
                    while (rdr.Read())
                    {
                        zip = rdr.GetInt32(0);
                        City tmp_city = new City(zip, rdr.GetString(1), rdr.GetString(2));
                        cities.Add(zip, tmp_city);
                    }
                    
                }catch(MySqlException ex)
                {
                    Console.WriteLine("Error: {0}", ex.ToString());
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                first_start = true;
            }
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
