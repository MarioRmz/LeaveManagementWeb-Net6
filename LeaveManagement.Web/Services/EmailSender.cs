using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LeaveManagement.Web.Services
{
    public class EmailSender : IEmailSender
    {
        //Estas variables y el constructor EmailSender se generaron desde Program.cs 
        //cuando la linea EmailSender se encontraba en rojo
        private string smtpServer;
        private int smtpPort;
        private string fromEmailAddress;

        public EmailSender(string smtpServer, int smtpPort, string fromEmailAddress)
        {
            this.smtpServer = smtpServer;
            this.smtpPort = smtpPort;
            this.fromEmailAddress = fromEmailAddress;
        }

        //Implementacion de la interfaz IEmailSender
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage
            {
                From = new MailAddress(fromEmailAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            //Agrega destinatario
            message.To.Add(new MailAddress(email));

            //Inicializacion del cliente con los datos inyectados
            //Esto se simplifico de un using statement normal, no te alarmes
            using var client = new SmtpClient(smtpServer, smtpPort);
            client.Send(message);

            return Task.CompletedTask;
        }
    }
}
