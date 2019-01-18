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
        public void SendMail(string receiveMail, string receiveName, string mailContent)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            MailAddress from = new MailAddress("tienbac250496@gmail.com", "My Admin");
            MailAddress to = new MailAddress(receiveMail, receiveName);
            MailMessage message = new MailMessage(from, to);
            message.Body = mailContent;
            message.Subject = "Assignment Authentication Verify";
            NetworkCredential myCreds = new NetworkCredential("tienbac250496@gmail.com", "brhfeoigofkfnyid", "");
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
    }
}
