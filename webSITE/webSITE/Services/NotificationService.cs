using webSITE.Models;
using webSITE.Services.Contracts;

namespace webSITE.Services
{
    public class NotificationService : INotificationService
    {
        private readonly Queue<Notification> _notifications = new Queue<Notification>();

        public Queue<Notification> Notifications { get { return _notifications; } }

        public void AddNotification(NotificationType type, string title, string message)
        {
            _notifications.Enqueue(new Notification
            {
                Type = type,
                Title = title,
                Message = message
            });
        }
    }
}
