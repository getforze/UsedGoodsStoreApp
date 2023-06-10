using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit.Text;


namespace UsedGoodsStoreApp.Server.Services
{
    public class EmailReporting
    {
        public Configuration Configuration { get; set; }

        public EmailReporting()
        {
        }
        public bool Send(string email, string message)
        {
            var Message = message;

            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Test", "lukaszmalanowski13@gmail.com"));
            mailMessage.To.Add(new MailboxAddress("User", email));
            mailMessage.Subject = "Zamówienie - sklep";
            mailMessage.Body = new TextPart(TextFormat.Text)
            {
                Text = $"{Message}"

            };

            MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                smtpClient.Connect("smtp.office365.com", 587, false);
                smtpClient.Authenticate("lukaszmalanowski13@gmail.com", "test");
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex) 
            { throw ex; }
            return true;
        }
    }
}
