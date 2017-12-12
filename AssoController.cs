using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using webpidev.Models;

namespace webpidev.Controllers
{
    public class AssoController : Controller
    {

        public ActionResult Index(string search, string SearchBy, string Type)
        {


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response;
            if (search != null)

            {
                response = Client.GetAsync("pidev-web/api/users/test/" + Type + "/" + SearchBy + "/" + search).Result;
            }
            else
            {


                response = Client.GetAsync("pidev-web/api/users/").Result;
            }


            if (response.IsSuccessStatusCode == true)
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
    }
}
