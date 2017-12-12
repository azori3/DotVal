using DATA;
using pidevDomain;
using Rotativa;
using Service;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using webpidev.Models;

namespace webpidev.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        ServiceUser su = null;
        ReclamationService rs = null;
        ServiceAdmin sa = null;
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = Client.GetAsync("pidev-web/api/users").Result;
            if(response.IsSuccessStatusCode == true )
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;
               // IEnumerable<Users> u = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;

                return View();
            }
            else
            {
                return View();
            }

   
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("users");
        }
        [HttpGet]
        public ActionResult Index(string search , string SearchBy, string Type)
        {
            

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response;
            if(search != null)
            
             {
                response = Client.GetAsync("pidev-web/api/users/test/Volunteer/" + SearchBy + "/" + search).Result;
                if (response.Content.Headers.ContentLength > 2)
                {
                    ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;
                    // IEnumerable<Users> u = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;


                    return View();

                }
                else
                {
                    ViewBag.msg1 = "No user found with typed word " + search;
                    return View();
                }
            }
            else
            {
               

                response = Client.GetAsync("pidev-web/api/users/vol").Result;
            } 

       
            if  ( response.IsSuccessStatusCode == true)  
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;
                // IEnumerable<Users> u = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;

                return View();
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Create(Users user)
        {

           
            return View();
        }
        public ActionResult Report(int id)
        {
            user user = null;
            su = new ServiceUser();
            user = su.GetById(id);
            ViewBag.id = id;
            ViewBag.mail = user.mail;
            return View();
        }
    

        public ActionResult Login(string mail,string pass)
        {
            pidevDomain.Admin a = null;
            
               sa = new ServiceAdmin();
         

            if(mail != null)
            {
                a = sa.Get(e => e.mail == mail);
                if (a.password == pass && a.mail==mail)
                { return RedirectToAction("Index"); }

                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

            
            
        }

        [HttpPost]
        public ActionResult Report(ReportModele r, int id)
        {
            user user = null;
            su = new ServiceUser();
            rs = new ReclamationService();
            Report reports = new Report();

            reports.Sujet = r.Sujet;
            reports.mail = r.mail;
            reports.DateBanneBegin = r.DateBanneBegin;
            reports.DateBanneEnd = r.DateBanneEnd;

            user = su.GetById(id);
            rs.Add(reports);
            rs.Commit();

            su.email(user.mail, "issamm11", r.Sujet, r.mail);

            if (reports.DateBanneEnd > reports.DateBanneBegin)
            {
                user.numberAction = "1";
                su.Update(user);
                su.Commit();
            }
            ViewBag.id = id;
            ViewBag.mail = user.mail;
            return View();
        }
        public ActionResult BillChart()
        {
            var context = new CGAContext();
        var CountM = context.users.SqlQuery("Select * from users where gender='Male'").Count();
            var CountF = context.users.SqlQuery("Select * from users where gender='Female'").Count();
            new Chart(width: 800, height: 200).AddSeries(chartType: "pie", xValue: new[] { "Male", "Female" }, yValues: new[] { CountM,CountF }).Write("png");
            return View();

        }
        public ActionResult Logout()
        {   
            return RedirectToAction("Login");

        }
        // GET : User/Index/4
        public ActionResult Unblock(int id)
        {
            user user = null;
            su = new ServiceUser();
            rs = new ReclamationService();

            

            user = su.GetById(id);
            user.numberAction =null;
            su.Update(user);
            su.Commit();
            

            return RedirectToAction("Index");
        }
     

        public ActionResult ListReport()
        {
            List<ReportModele> tl = new List<ReportModele>();
            rs = new ReclamationService();
            foreach (var item in rs.GetAll())
            {
                ReportModele t = new ReportModele();
                t.Id = item.Id;
                t.Sujet = item.Sujet;
                t.mail = item.mail;
                tl.Add(t);
            }


            return View(tl);
           
        }
        public ActionResult getVol(string search, string SearchBy, string Type) {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response;
            if (search != null)

            {
                response = Client.GetAsync("pidev-web/api/users/test/Asso/" + SearchBy + "/" + search).Result;
                if (response.Content.Headers.ContentLength >2)
                {
                    ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;
                    // IEnumerable<Users> u = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;
                   

                    return View();

                }
                else
                {
                    ViewBag.msg1 = "No user found with typed word "+search;
                    return View();
                }
            }
            else
            {


                response = Client.GetAsync("pidev-web/api/users/asso").Result;
            }


            if (response.Content.Headers.ContentLength != 0)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;
                // IEnumerable<Users> u = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;

                
                return View();
                
            }
            else
            {
                 
                return View();
            }

        }

        ReportService rss = null;
        
        public ActionResult ReportDetails(int id)
        {
            Report report = null;
            rss = new ReportService();
            report = rss.GetById(id);
            ViewBag.id = report.Id;
            ViewBag.mail = report.mail;
            ViewBag.sujet = report.Sujet;
            ViewBag.DDB = report.DateBanneBegin;
            ViewBag.DEB = report.DateBanneEnd;



            return View();
        }

     
             public ActionResult Delete(int id)
        {
            Report report = null;
            rss = new ReportService();
            report = rss.GetById(id);
            rss.Delete(report);
            rss.Commit();



            return RedirectToAction("ListReport");
        }
        public ActionResult ExportPdf(int id)
        {

            return new ActionAsPdf("ReportDetails/"+id)
            {

                FileName = Server.MapPath("~/Content/List.pdf")

            };

        }
    }
}