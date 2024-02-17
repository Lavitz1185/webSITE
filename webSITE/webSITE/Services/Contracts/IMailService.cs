using webSITE.Models;

namespace webSITE.Services.Contracts
{
    public interface IMailService
    {
        Task<bool> SendMailAsync(MailData mailData);
    }
}
