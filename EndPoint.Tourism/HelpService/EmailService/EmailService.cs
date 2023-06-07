using EndPoint.FinderProject.Models.EmailClasses;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.HelpService.EmailService
{
    public interface IEmailService
    {
       public bool SendMail(MailData mailData);
       
    }
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        public EmailService(IOptions<MailSettings> mailSettingsOptions)
        {
            _mailSettings = mailSettingsOptions.Value;
        }
        public bool SendMail(MailData mailData)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(mailData.Email));
                message.From = new MailAddress(_mailSettings.SenderEmail);
                message.Subject = mailData.Subject;
                message.Body = mailData.Body;
                message.IsBodyHtml = true;

                using (var client = new System.Net.Mail.SmtpClient(_mailSettings.Server))
                {
                    client.Port = 587;
                    client.Credentials = new NetworkCredential(_mailSettings.UserName, _mailSettings.Password);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }

            return true;
        }
        
    }
}
