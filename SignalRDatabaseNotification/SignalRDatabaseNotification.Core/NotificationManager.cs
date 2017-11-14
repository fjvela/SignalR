using SignalRDatabaseNotification.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDatabaseNotification.Core
{
    public class NotificationManager
    {
        private DataBaseContext context;
        public event OnChangeEventHandler NotificationOnChanged;

        public NotificationManager(DataBaseContext context)
        {
            this.context = context;
        }

        public IList<Message> GetNotifications()
        {
            return context.Messages.AsQueryable().ToList();
        }

        public void ActivateImmediateNotification()
        {
            var query = context.Messages.AsQueryable();

            ImmediateNotificationRegister<Message> notification = new ImmediateNotificationRegister<Message>(
             context,
             query);

            notification.OnChanged += NotificationOnChanged;
        }
    }
}
