using System;
using ThreeLayerArch.Business.Interfaces;

namespace ThreeLayerArch.Business.Notifications
{
	public class Notifier : INotifier
	{
        private List<Notification> _notifications;

		public Notifier()
		{
            _notifications = new List<Notification>();
		}

        public void Handler(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetAllNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}

