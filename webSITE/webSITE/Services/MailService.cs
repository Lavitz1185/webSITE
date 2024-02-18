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
        private readonly MailSettings _mailSettings;
        private readonly ILogger<MailService> logger;

        public MailService(IOptions<MailSettings> mailSettingsOptions, ILogger<MailService> logger)
        {
            _mailSettings = mailSettingsOptions.Value;
            this.logger = logger;
        }

        public async Task<bool> SendMailAsync(MailData mailData)
        {
            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                    emailMessage.From.Add(emailFrom);
                    MailboxAddress emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                    emailMessage.To.Add(emailTo);

                    emailMessage.Subject = mailData.EmailSubject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.HtmlBody = mailData.EmailBody;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();

                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        mailClient.CheckCertificateRevocation = false;
                        await mailClient.ConnectAsync(_mailSettings.Server, _mailSettings.Port, SecureSocketOptions.StartTls);
                        await mailClient.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
                        await mailClient.SendAsync(emailMessage);
                        await mailClient.DisconnectAsync(true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                // Exception Details
                return false;
            }
        }

    }
}