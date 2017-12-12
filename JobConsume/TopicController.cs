using Domain.Entity;
using RestSharp;
using Rotativa.MVC;
using Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
namespace MVCProject.Controllers
{
    public class TopicController : Controller
    {
        ServiceTopic st = new ServiceTopic();
        ServiceFavoris sf = new ServiceFavoris();
        ServiceMessage sm = new ServiceMessage();
        ServiceLikes sl = new ServiceLikes();
        ServiceFiltre sfil=new ServiceFiltre();
        ServiceUser su = new ServiceUser();
        public static users currentuser = null;

        // GET: Topic
        public ActionResult Topic()
        {
              var client = new RestClient("http://localhost:18080/pidev-web/api/");
              var request = new RestRequest("topic", Method.GET);
              request.AddHeader("Content-type", "application/json");
            ViewBag.test = "";

              IRestResponse<List<topic>> topics = client.Execute<List<topic>>(request);


            // var topics = st.GetAll();
            // return View(topics);
            List<int> nbmsg = new List<int>();
            foreach (var item in topics.Data)
            {
                nbmsg.Add(sm.GetMessageByIdTopic(item.idTopic).Count);
            }
            
            ViewBag.fav = sf.GetAll();
            ViewBag.nbmsg = nbmsg;
            ViewBag.favoris = sf.GetFavorisByUser(currentuser.id);
            return View(topics.Data);

        }

        // favoris
        public ActionResult DetailsFavoris()
        {
          
            return View(sf.GetFavorisByUser(currentuser.id));
        }
        public ActionResult CreateFavoris(int id)
        {
            favoris f = new favoris();
            f.idtopic = id;
            f.iduser = currentuser.id;
            f.date = DateTime.Now;
            sf.Add(f);
            sf.Commit();
            ViewBag.favoris = sf.GetFavorisByUser(currentuser.id);
            return RedirectToAction("Topic");


        }
        public ActionResult DeleteFavoris(int idtopic)
        {
            favoris f = new favoris();
            f.iduser = currentuser.id;
            f.idtopic = idtopic;
            sf.Deletefavoris(f);
            sf.Commit();
            ViewBag.favoris = sf.GetFavorisByUser(currentuser.id);
            return RedirectToAction("Topic");
        }
       
        public ActionResult Login()
        {

            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(HttpPostedFileBase photo)
        {
            var email = Request.Form["email"];
            var password = Request.Form["password"];
          
            currentuser = su.GetUser(password,email);

            if (currentuser!=null)
            {
                return RedirectToAction("Topic");
            }
            else
            {
                return RedirectToAction("Login");
            }


        } 
        


        //message
        public ActionResult Message(int idTopic,string sujet)
        {

            /*   var client = new RestClient("http://localhost:18080/pidev-web/api/");
            var request = new RestRequest("message", Method.GET);
            request.AddHeader("Content-type", "application/json");


            IRestResponse<List<message>> messages = client.Execute<List<message>>(request);
         foreach (var item in messages.Data)
           {
               if (item.idTopic!= id)
               {
                   messages.Data.Remove(item);
               }
           }*/
            ViewBag.likes = sl.GetAll();
            var messages = sm.GetMessageByIdTopic(idTopic);
            List<int> nblike = new List<int>();

            foreach (var msg in messages)
            {
                nblike.Add(sl.GetFavorisBymsg(msg.idMessage));
            }
            ViewBag.topic = sujet;
            ViewBag.idtopic = idTopic;
            ViewBag.nblike = nblike;

            return View(messages);
        }
        [HttpPost]
        public ActionResult Message(HttpPostedFileBase photo)
        {

            var filtre = sfil.GetAll();
            int i = 0;
           
                var contenu = Request.Form["Message"];
                var msg = new message();
                msg.contenu = (contenu);
           // while (i < filtre.Count() && msg.contenu.Contains(filtre.ElementAt(i).text) )
           // {
             //   i = i + 1;
           // }
            bool verif = false;
            foreach (var item in filtre)
            {
                if (msg.contenu.Contains(item.text))
                {
                    verif = true;
                }
            }
            if (!verif)
            {
                    var restClient = new RestClient("http://localhost:18080/pidev-web/api/");
                    restClient.AddDefaultHeader("accept", "*/*");
                    var request = new RestRequest("message?idUser="+ currentuser.id +"&idTopic=1", Method.POST);
                    request.AddJsonBody(new
                    {
                        contenu = contenu
                    });
                    var response = restClient.Execute(request);
                    ViewBag.test = "message ajouté avec succes";
                // ViewBag.idtopic = idTopic;
                // return RedirectToAction("Message");
                return Message(1, "topic1");

            }
            return Message(1, "topic1"); 
          
        }


        // like
        public ActionResult CreateLikes(int id,int idt,string sujet)
        {
            likes  l= new likes();
            l.iduser = currentuser.id;
            l.idmessage = id;
            l.date = DateTime.Now;
            sl.Add(l);
            sl.Commit();
            ViewBag.variable = id;
            return RedirectToAction("Message", new { idTopic = idt, sujet = sujet });
        }
        public ActionResult DeleteLikes(int idm, int idt, string sujet)
        {
            likes l = new likes();
            l.iduser = currentuser.id;
            l.idmessage = idm;

            sl.Deletelike(l);
            sl.Commit();
            return RedirectToAction("Message", new { idTopic = idt, sujet = sujet });
        }


        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Topic/Delete/5
       
       
        // POST: Topic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       public ActionResult ExportPdf()
        {

            return new ActionAsPdf("Topic")
            {

                FileName = Server.MapPath("~/Content/List.pdf")

            };

        }
        public ActionResult Statistique()
        {
            string[] listmsg =new string[100]   ;
            int[] nblike = new int[100];
            var messages = sm.GetAll();
            for (int i = 0; i < messages.Count(); i++)
            {
                listmsg[i] = messages.ElementAt(i).contenu;
                nblike[i] = sl.GetFavorisBymsg(messages.ElementAt(i).idMessage);
              //  listmsg.SetValue(messages.ElementAt(i).contenu, i);
              //  nblike.SetValue(sl.GetFavorisBymsg(messages.ElementAt(i).idMessage), i);

            }
            
            new Chart(width: 800, height: 400).AddSeries(chartType: "Column", xValue: listmsg, yValues:nblike).Write("png");
            return View("Chart");
            
        }
        public ActionResult BillChart()
        {
            string[] listmsg = new string[100];
            int[] nblike = new int[100];
            var messages = sm.GetAll();
            for (int i = 0; i < messages.Count(); i++)
            {
                listmsg[i] = messages.ElementAt(i).contenu;
                nblike[i] = sl.GetFavorisBymsg(messages.ElementAt(i).idMessage);
                //  listmsg.SetValue(messages.ElementAt(i).contenu, i);
                //  nblike.SetValue(sl.GetFavorisBymsg(messages.ElementAt(i).idMessage), i);

            }
            new Chart(width: 800, height: 400).AddSeries(chartType: "pie", xValue: listmsg, yValues: nblike).Write("png");
            return View("PieChart");

        }

    }
}
