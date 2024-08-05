using webSITE.Models;

namespace webSITE.Services.Contracts
{
    public interface IToastrNotificationService
    {
        string? GetNotificationJson();
        void AddNotification(ToastrNotification notification);
    }
}
