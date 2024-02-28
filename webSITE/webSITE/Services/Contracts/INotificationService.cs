using webSITE.Models;

namespace webSITE.Services.Contracts
{
    public interface INotificationService
    {
        void AddNotification(ToastrNotification notification);
        string TempDataKey { get; }
    }
}
