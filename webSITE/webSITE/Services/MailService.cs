using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using webSITE.Configuration;
using webSITE.Models;
using webSITE.Services.Contracts;

namespace webSITE.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettingsOptions _mailSettings;
        private readonly ILogger<MailService> logger;

        public MailService(IOptionsSnapshot<MailSettingsOptions> mailSettingsOptions, ILogger<MailService> logger)
        {
            _mailSettings = mailSettingsOptions.Value;
            this.logger = logger;
        }

        public async Task<bool> SendMailAsync(MailData mailData)
        {
            try
            {
                using (var emailMessage = new MimeMessage())
                {
                    var emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                    emailMessage.From.Add(emailFrom);
                    var emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                    emailMessage.To.Add(emailTo);

                    emailMessage.Subject = mailData.EmailSubject;

                    var emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.HtmlBody = mailData.EmailBody;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();

                    using (var mailClient = new SmtpClient())
                    {
                        mailClient.CheckCertificateRevocation = false;
                        await mailClient.ConnectAsync(_mailSettings.Server, _mailSettings.Port, SecureSocketOptions.StartTls);
                        await mailClient.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
                        await mailClient.SendAsync(emailMessage);
                        await mailClient.DisconnectAsync(true);
                    }
                }

                logger.LogDebug("Email terkirim ke {@emailTo}. TimeStamp : {@timeStamp}", 
                    mailData.EmailToId, DateTime.Now);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, 
                    "Email gagal terkirim ke {@emailTo}. TimeStamp : {@timeStamp}. Exception Message : {@message}",
                    mailData.EmailToId, DateTime.Now, ex.Message);

                return false;
            }
        }

    }
}