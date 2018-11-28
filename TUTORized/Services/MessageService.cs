using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Services.Abstract;
using SendGrid;
using SendGrid.Helpers;
using SendGrid.Helpers.Mail;

namespace TUTORized.Services
{
    public class MessageService : IMessageService
    {
        public static string SendGridTutorizedTemplate;

        public static string SendGridApiKey;

        public Task SendAppointmentMadeEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(SendGridApiKey);

            var msg = new SendGridMessage
            {
                TemplateId = SendGridTutorizedTemplate,
                From = new EmailAddress("noReply@noReply.net", "Tutorized"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };


            return client.SendEmailAsync(msg);
        }

        public Task SendConfirmEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(SendGridApiKey);

            var msg = new SendGridMessage
            {
                TemplateId = SendGridTutorizedTemplate,
                From = new EmailAddress("noReply@noReply.net", "Tutorized"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };


            return client.SendEmailAsync(msg);
        }
    }
}
