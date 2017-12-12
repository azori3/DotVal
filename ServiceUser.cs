using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

using Service.Patern;
using DATA.Infrastructure;
using pidevDomain;

namespace Services
{
    public class ServiceUser : Service<user>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public ServiceUser() : base(utwk)
        {
        }

        public void email(String email,String pass, String subject, String body)
        {
            try { 
             SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("wadi.zaatour@esprit.tn", pass);
            MailMessage msg = new MailMessage();
            msg.To.Add(email);
            msg.From = new MailAddress("wadi.zaatour@esprit.tn");
            msg.Subject = subject;
            msg.Body = body;
            client.Send(msg);
            } catch(Exception e)
            {
                
            }
        }
 
    }
}
