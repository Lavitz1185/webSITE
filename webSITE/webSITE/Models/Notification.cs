namespace webSITE.Models
{
    public class Notification
    {
        public NotificationType Type { get; set; } = NotificationType.Info;
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
