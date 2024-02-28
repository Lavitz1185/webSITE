namespace webSITE.Models
{
    public class ToastrNotification
    {
        public ToastrNotificationType Type { get; set; } = ToastrNotificationType.Info;
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
