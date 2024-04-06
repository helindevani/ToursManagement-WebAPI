
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using ToursDatabase.ServiceContracts;

namespace ToursDatabase.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("h99304098@gmail.com"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = message;

            emailToSend.Body = bodyBuilder.ToMessageBody();

            using (var emailClient = new SmtpClient())
            {
                emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await emailClient.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await emailClient.AuthenticateAsync("h99304098@gmail.com", "hvjvrtldpksmvzqf");
                await emailClient.SendAsync(emailToSend);
                await emailClient.DisconnectAsync(true);
            }
        }
    }
}
