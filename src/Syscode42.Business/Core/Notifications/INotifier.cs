using System.Collections.Generic;

namespace Syscode42.Business.Core.Notifications
{
    public interface INotifier
    {
        bool HasNotifications();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
	}
}
