using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AspNetFinalProject
{
    public static partial class Extension
    {
        static public bool SendMail(this string Email, string Subject, string Message)
        {
            if (string.IsNullOrEmpty(Subject))
                throw new ArgumentNullException("Subject");
            if (string.IsNullOrEmpty(Message))
                throw new ArgumentNullException("Message");
            if (string.IsNullOrEmpty(Email))
                throw new ArgumentNullException("Email");

            MailMessage mail = new MailMessage(new MailAddress("fullstackstaff@mail.ru"), new MailAddress(Email))
            {
                Subject = Subject,
                Body = Message,
                IsBodyHtml = true
            };

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.mail.ru",
                Credentials = new NetworkCredential("fullstackstaff", "!d@v#l0pmentgroup20!9"),
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };

            int retry = 3;
            do
            {
                try
                {
                    client.Send(mail);
                    return true;
                }
                catch (Exception ex) { }

                retry--;
            } while (retry > 0);

            return false;
        }
    }
}