namespace webSITE.Services.Contracts
{
    public interface INotificationService
    {
        void AddNotification(NotificationType type, string title, string message);
        Queue<Notification> Notifications { get; }
    }

    public enum NotificationType
    {
        Info, Warning, Success, Error
    }

    public class Notification
    {
        public NotificationType Type { get; set; } = NotificationType.Info;
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
