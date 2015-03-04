using Eventzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Eventzer
{

    public class WebApiApplication : System.Web.HttpApplication
    {
        List<Event> events = new List<Event>();
        bool first_start = false;
        
        protected void Application_Start()
        {
            //loading in some test data on application startup
            if(!first_start)
            {
                for (int i = 1; i <= 10; i++)
                {
                    events.Add(new Event(i));    
                }
                Application["Events"] = events;
                first_start = true;
            }
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
