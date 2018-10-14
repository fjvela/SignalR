﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApplicationChat.App_Start.Startup))]

namespace WebApplicationChat.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapAzureSignalR(this.GetType().FullName);
        }
    }
}