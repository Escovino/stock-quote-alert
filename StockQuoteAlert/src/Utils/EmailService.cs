using System;
using System.Net;
using System.Net.Mail;
//TODO Revisar o serviço de envio de email
namespace StockPriceMonitor.Utils
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;
        private readonly string _fromEmail;

        public EmailService(string smtpServer, int smtpPort, string smtpUser, string smtpPass, string fromEmail)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUser = smtpUser;
            _smtpPass = smtpPass;
            _fromEmail = fromEmail;
        }

        public void SendEmailAlert(string toEmail, string subject, string body)
        {
            using (var message = new MailMessage(_fromEmail, toEmail))
            {
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient(_smtpServer, _smtpPort))
                {
                    client.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }
    }
}