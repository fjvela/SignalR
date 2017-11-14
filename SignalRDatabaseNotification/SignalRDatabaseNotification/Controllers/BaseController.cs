using SignalRDatabaseNotification.Code;
using SignalRDatabaseNotification.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRDatabaseNotification.Controllers
{
    public class BaseController : Controller
    {
        protected NotificationManager notificationManager;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            notificationManager = new NotificationManager(new Data.DataBaseContext());
            //notificationManager.NotificationOnChanged += NotificationManager_NotificationOnChanged;
            //notificationManager.GetNotifications();
        }

        //private void NotificationManager_NotificationOnChanged(object sender, System.Data.SqlClient.SqlNotificationEventArgs e)
        //{
        //    if (e.Type == System.Data.SqlClient.SqlNotificationType.Change)
        //    {
        //        NotificationHub.NewNotification("New notification!");
        //    }
        //}
    }
}