using SignalRDatabaseNotification.Code;
using SignalRDatabaseNotification.Core;
using SignalRDatabaseNotification.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SignalRDatabaseNotification
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private string connString = ConfigurationManager.ConnectionStrings["DataBaseContext"].ConnectionString;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ImmediateNotificationRegister<Message>.StartMonitor(connString);
            SetupSQLDependency();
        }

        private void SetupSQLDependency()
        {
            DataBaseContext context = new DataBaseContext();

            NotificationManager notificationManager = new NotificationManager(new Data.DataBaseContext());
            notificationManager.NotificationOnChanged += NotificationManager_NotificationOnChanged;
            notificationManager.ActivateImmediateNotification();
            
        }

        private void NotificationManager_NotificationOnChanged(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == System.Data.SqlClient.SqlNotificationType.Change)
            {
                NotificationHub.NewNotification("New notification!");
            }
        }

   

        protected void Application_End()
        {
            ImmediateNotificationRegister<Message>.StopMonitor(connString);
        }
    }
}