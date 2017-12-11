using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using JobConsume.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace JobConsume.Areas.Administrator.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Index()
        {



            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080/");
            Client.DefaultRequestHeaders.Accept.Clear();
            ViewBag.country = "";
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage reponse = Client.GetAsync("pidev-web/api/jobs").Result;
            Console.WriteLine("ali" + reponse);

            Console.WriteLine("aaa");
            // String res = reponse.Content.ReadAsStringAsync<IEnumerable<job>>().Result;
            Debug.WriteLine("DEBUG: " + reponse);

            if (reponse.IsSuccessStatusCode == true)
            {
                //  
                ViewBag.result = reponse.Content.ReadAsAsync<IEnumerable<job>>().Result;


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
            return View("Create");
        }
        //public async Task<HttpResponseMessage> PostResult(string url, ResultObject resultObject)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        HttpResponseMessage response = new HttpResponseMessage();
        //        try
        //        {
        //            response = await client.PostAsJsonAsync(url, resultObject);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex
        //        }
        //        return response;
        //    }
        //}


        [HttpPost]
        public ActionResult Create(job job)
        {

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://127.0.0.1:18080/");
            //HttpResponseMessage response = new HttpResponseMessage();


            ////    response = client.PostAsync("pidev-web/api/jobs", new StringContent(
            ////    new JavaScriptSerializer().Serialize(job), Encoding.UTF8, "application/json")).Result;
            ////Debug.WriteLine("aa"response.Content.ToString);
            //client.PutAsJsonAsync<job>("pidev-web/api/jobs", job).ContinueWith((postTask)=> postTask.Result.EnsureSuccessStatusCode());
            //    return View();


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://127.0.0.1:18080/pidev-web/api/jobs");
            request.Method = "POST";
            request.ContentType = "application/json";
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                string json = serializer.Serialize(job);
                sw.Write(json);
                sw.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return View("Index");

        }


    }
}