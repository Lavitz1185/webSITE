using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using webSITE.Models;
using webSITE.Services.Contracts;

namespace webSITE.Services
{
    public class NotificationService : INotificationService
    {
        private readonly string _tempDataKey = "WebSITE.Notification";
        private readonly ITempDataDictionary _tempData;

        public string TempDataKey { get { return _tempDataKey; } }

        public NotificationService(
            IHttpContextAccessor httpContextAccessor,
            ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            var httpContext = httpContextAccessor.HttpContext;

            _tempData = tempDataDictionaryFactory.GetTempData(httpContext);
        }

        public void AddNotification(ToastrNotification notification)
        {
            if (_tempData.Peek(_tempDataKey) == null)
            {
                _tempData[_tempDataKey] = JsonConvert.SerializeObject(new List<ToastrNotification>());
            }

            var list = JsonConvert
                .DeserializeObject<List<ToastrNotification>>(_tempData[_tempDataKey] as string);

            list.Add(notification);

            _tempData[_tempDataKey] = JsonConvert.SerializeObject(list);
            _tempData.Keep(_tempDataKey);
        }
    }
}
