using webSITE.Models;

namespace webSITE.Services.Contracts
{
    public interface INotificationService
    {
        void AddNotification(NotificationType type, string title, string message);
        Queue<Notification> Notifications { get; }
    }
}
