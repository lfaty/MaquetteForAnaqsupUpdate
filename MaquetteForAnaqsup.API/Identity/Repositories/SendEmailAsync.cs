using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace MaquetteForAnaqsup.API.Identity.Repositories
{
    public class SendEmailAsync : IEmailSender
    {
        Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            #region Parametre Email
            var From = "faty.laminefaty@gmail.com";
            var Password = "mhvl egiq nzfm dakh";
            #endregion

            using (MailMessage message = new MailMessage(From, email))
            {
                message.Subject = subject;
                message.Body = htmlMessage;
                message.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetCre = new NetworkCredential(From, Password);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetCre;
                    smtp.Port = 587;
                    smtp.Send(message);
                }
            }
            return Task.CompletedTask;
        }
    }
}
