
using HDD.Infrastructure.Services;
using HDD.Web.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;

namespace HDD.Web.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger _logger;
        private readonly EmailOptions _options;

        public EmailService(ILoggerFactory loggerFactory, IOptions<EmailOptions> options)
        {
            _logger = loggerFactory.CreateLogger<EmailService>();
            _options = options.Value;
        }

        public void SendEmail(string email, string subject, string message, bool html = false)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_options.AdminEmail);
            mailMessage.To.Add(email);
            mailMessage.Body = message;
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = html;

            using (var client = new SmtpClient(_options.MailServer, _options.MailPort))
            {
                client.Credentials = new System.Net.NetworkCredential(_options.MailUserId, _options.MailPassword);
                client.Send(mailMessage);
            }
        }

        public void SendException(Exception ex, string subject = " HDD Error")
        {
            string msg = "<pre>" + ex.ToString() + "</pre>";
            SendEmail(_options.SupportEmail, subject, msg, true);
        }


        void IEmailService.SendEmail(string fromEmail, string email, string subject, string message, bool html)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(fromEmail);
            mailMessage.To.Add(email);
            mailMessage.Body = message;
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = html;

            using (var client = new SmtpClient(_options.MailServer, _options.MailPort))
            {
                client.Credentials = new System.Net.NetworkCredential(_options.MailUserId, _options.MailPassword);
                client.Send(mailMessage);
            }
        }

    }
}

