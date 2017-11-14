using SignalRDatabaseNotification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRDatabaseNotification.Controllers
{
    public class NotificationController : BaseController
    {
        // GET: Notification
        public IList<NotificationModel> GetNotifications()
        {

            return notificationManager.GetNotifications().Select(x => new NotificationModel()
            {
                Date = x.Date.GetValueOrDefault(),
                Message = x.MessageText
            }).ToList();
        }
    }
}