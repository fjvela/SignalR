using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Data.SqlClient;

[assembly: OwinStartup(typeof(SignalRDatabaseNotification.App_Start.Startup))]

namespace SignalRDatabaseNotification.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}