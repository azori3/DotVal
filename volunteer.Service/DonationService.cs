using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using volunteer.domaine.entities;
using Volunteer.ServicePattern;

namespace volunteer.Service
{
    public class DonationService : ServiceP<donation>, IDonationServicecs
    {
        public static IDatabaseFactory dbfactory = new DatabaseFactory();
        public static IUnitOfWork uow = new UnitOfWork(dbfactory);
        public DonationService() : base(uow)
        {

        }

        public void email(String subject ,string body)
        {
            var fromAddress = new MailAddress("hichem.alouis123@gmail.com", "Hichem");
            var toAddress = new MailAddress("ali.methnani@esprit.tn", "To Name");
            const string fromPassword = "tunis123456";
    

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            }


        public List<donation> sortedByDate()
        {
            List<donation> lst = new List<donation>();
            var results = from g in dbfactory.DataContext.donation orderby g.dateajout descending select g;


            foreach (var item in results)
            {
                lst.Add(item);
            }
            return lst;
        }
        public List<donation> donDispo()
        {
            var results = from g in dbfactory.DataContext.donation
                          where (g.disponibilite =="disponible")
                          select g;
            List<donation> lst = new List<donation>();
            foreach (var item in results)
            {
                lst.Add(item);
            }
            return lst;
        }


    }



}