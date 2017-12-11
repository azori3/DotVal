using Service.pattern;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entities;
using System.Web.Script.Serialization;

namespace Services
{
    public class ActionService : Service<action>, IActionService
    {

        static DatabaseFactory Dbf = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(Dbf);
        

        public ActionService(): base(utw)
        {
        }

      

        public IEnumerable<action> FindAll()
        {
            return utw.GetRepository<action>().GetAll();
        }
        //DELETEE
        public String DeleteAction(action action)
        {



            HttpWebRequest request = (HttpWebRequest)
             WebRequest.Create("http://localhost:18080/pidev-web/rest/Actionss/"+action.idAction);
             request.Method = "DELETE";
             request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    id = action.idAction
                });

                streamWriter.Write(json);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string content = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }
            return (content);

        }

        public String ModifyArticle(action action)
        {
            DateTime dt = DateTime.Now;
            String ds = dt.ToString("yyyy-MM-dd");

            HttpWebRequest request = (HttpWebRequest)
             WebRequest.Create("http://localhost:18080/wediscus-web/wediscusrest/article");



            request.Method = "PUT";
            request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                   // id = action.idAction,
                    //datePublication = ds,
                    title = action.titreAction,

                    description = action.discriptionAction,
                   // typearticle = action.typearticle,
                   // imageURL = action.ImageURL,

                });

                streamWriter.Write(json);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string content = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }
            return (content);

        }

        public IEnumerable<action> actionByTitle(string title)
        {
           
                return utw.GetRepository<action>().GetAll().Where(f => f.titreAction.Contains(title));

          }

        public virtual void AddAction(action entity)
        {
            utw.GetRepository<action>().Add(entity);
        }


    }
}
