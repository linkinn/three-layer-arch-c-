using ThreeLayerArch.Business.Notifications;

namespace ThreeLayerArch.Business.Interfaces
{
	public interface INotifier
	{
		bool HasNotification();

		List<Notification> GetAllNotifications();

		void Handler(Notification notification);
	}
}

