using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationChat.Hubs
{
    public class ChatHub : Hub
    {


        public void SendNewUser(string user)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.newChatMsg($"{DateTime.Now} The {user} connected!");
        }

        public void Send(string user, string msg)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.newChatMsg($"{DateTime.Now} {user}: {msg}");
        }
    }
}