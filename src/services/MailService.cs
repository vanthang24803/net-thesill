
using Api.TheSill.src.common.helpers;
using Api.TheSill.src.domain.dtos.mail;
using Api.TheSill.src.interfaces;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Api.TheSill.src.services {
    public class MailService : IMailService {

        private readonly MailSettings mailSettings;

        public MailService(IOptions<MailSettings> options) {
            mailSettings = options.Value;
        }

        public async Task SendMailAsync(MailRequest mailRequest) {
            var email = new MimeMessage {
                Sender = MailboxAddress.Parse(mailSettings.Email)
            };
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder {
                HtmlBody = mailRequest.Message
            };
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            await smtp.ConnectAsync(mailSettings.Host, mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(mailSettings.Email, mailSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}