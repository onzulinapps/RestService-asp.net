using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Configuration;
using System.Diagnostics;
using SendGrid;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using Simplify.Mail;

namespace RestAPIPlanningActivities
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            //Probaremos com MaiMessage objeto de .NET por defecto usando un mail existente en un servidor de correo existente en mi caso outlook
            //string body = message.Body;
            MailMessage mail = new MailMessage()
            {
                Body = message.Body,
                Subject = "Confirmation Mail",
                IsBodyHtml = false
            };
            //asignar destinatario que ya me lo da la variable message en este programa
            //
            // de esta manera asignaria varios destinatarios
            //
            /*
            foreach (string item in destinatarios)
            {
                mail.To.Add(new MailAddress(item));
            }
            *  aqui en este programa solo necesito un destinatario en este caso
            */
            //aqui añado la direccion que necesito 
            mail.To.Add(new MailAddress(message.Destination));
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mail);
            //esto no lo usaremos y probaremos a hacerlo como explican en otro lado usando el SMTP de email
            /* 
            var myMessage = new SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new System.Net.Mail.MailAddress(
                                "Joe@contoso.com", "Joe S.");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;

            var credentials = new NetworkCredential(
                       ConfigurationManager.AppSettings["mailAccount"],
                       ConfigurationManager.AppSettings["mailPassword"]
                       );

            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
            */
            
            //colocamos el codigo del mailservice que voy ausar el mensaje a mandar
            //var message = "Some problem was happened at: ";
            //string messageEmail = "Confirm Email";
            //MailSender.Default.Send("onzulinapps@outlook.com", message.Destination, "Confirmation Email PlanningActivities: ", messageEmail + DateTime.Now, messageEmail);

        }
    }
}