using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Airplanes.Security
{
    public class MailVerify
    {
        public void SendMail(string receiveMail, string receiveName, string mailContent, string subject)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            MailAddress from = new MailAddress("eagleairline1707@gmail.com", "Eagle Airline");
            MailAddress to = new MailAddress(receiveMail, receiveName);
            MailMessage message = new MailMessage(from, to);
            message.Body = mailContent;
            message.Subject = subject;
            message.IsBodyHtml = true;
            NetworkCredential myCreds = new NetworkCredential("eagleairline1707@gmail.com", "iggzuapaoagalzam", "");
            client.Credentials = myCreds;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is:" + ex.ToString());
            }
            Console.WriteLine("Goodbye.");
        }

        //brhfeoigofkfnyid

    }
}
