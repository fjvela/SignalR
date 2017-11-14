using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRDatabaseNotification.Code
{
    public class NotificationHub : Hub
    {
  

        public static void NewNotification(string msg)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.newNotification(msg);
        }

        public static void ReloadPage()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.reloadPage();
        }


    }
}