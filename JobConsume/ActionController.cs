using Data.Infrastructure;
using Dev.Entities;
using Domain.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webapp.Models;

namespace Webapp.Controllers
{
    public class ActionController : Controller
    {
        ActionService actionService = new ActionService();
        MapService mapService = new MapService();
        UnitOfWork uow = new UnitOfWork(new DatabaseFactory());


        [Route("Action/Index")]
        public ActionResult Index(ActionModel actionModel)
        {
            if (Request.HttpMethod == "POST" && actionModel != null)
            {

                List<action> listByTitle = new List<action>(actionService.actionByTitle(actionModel.titreAction));
                ViewData["listAction"] = listByTitle;
                return View();
            }



            List<action> listAction = new List<action>();
            listAction = (List<action>)actionService.FindAll();
            ViewData["listAction"] = listAction;

            return View();
        }
        // GET: /Action/Accueil/

        [Route("Action/Accueil")]
        public ActionResult Accueil(ActionModel actionModel)
        {

            List<action> listAction = new List<action>();
            listAction = (List<action>)actionService.FindAll();
            ViewData["listAction"] = listAction;

            return View();
        }
        [Route("Action/Single/{id}")]
        public ActionResult DisplaySingle(int id)
        {
            ActionModel actionModel = new ActionModel();
            action article0 = new action();
            article0 = actionService.GetById(id);
            actionModel.titreAction = article0.titreAction;
            actionModel.discriptionAction = article0.discriptionAction;
            actionModel.dateDebutAction = article0.dateDebutAction;
            actionModel.dateFinAction = article0.dateFinAction;
            //int test = article0.localisation;
            actionModel.lag = (float)DisplayMap(article0.localisation).longitude;
            actionModel.lat = (float)DisplayMap(article0.localisation).altitude;

            actionModel.idAction = article0.idAction;


            return View(actionModel);
        }


        public mapaction DisplayMap(int id)
        {
            MapModel mapModel = new MapModel();
            mapaction article1 = new mapaction();
            article1 = mapService.GetById(id);
            mapModel.Lag = (float)article1.longitude;
            mapModel.Lat = (float)article1.altitude;

            return article1;



        }




        //test

        [Route("Action/test")]
        public ActionResult test(ActionModel actionModel)
        {

            List<action> listAction = new List<action>();
            listAction = (List<action>)actionService.FindAll();


            return View();
        }

        //testEnd


        [Route("Action/Delete/{id}")]
        public ActionResult DeleteAction(int id)
        {
            if (id != 0)
            {



                action action = new action();
                action.idAction = id;
                actionService.DeleteAction(action);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        // POST: Action/Create
        [HttpPost]
        public ActionResult Create(ActionModel actionModel, HttpPostedFileBase fa)
        {

            actionModel.imageAction = fa.FileName;
            action action = new action();
            mapaction mapaction = new mapaction();

            action.titreAction = actionModel.titreAction;
            action.dateDebutAction = actionModel.dateDebutAction;
            action.dateFinAction = actionModel.dateFinAction;
            action.imageAction = actionModel.imageAction;
            action.discriptionAction = actionModel.discriptionAction;
            action.localisation = mapaction.idMap;

            mapaction.altitude = actionModel.lat;
            mapaction.longitude = actionModel.lag;
            uow.GetRepository<mapaction>().Add(mapaction);

            uow.GetRepository<action>().Add(action);

            uow.Commit();
            //Sauvgarde de l'image

            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), fa.FileName);
            fa.SaveAs(path);
            return RedirectToAction("Index");


        }

        [Route("Article/Modify/{id}")]
        public ActionResult ModifyArticle(int id, ActionModel actionmodel, HttpPostedFileBase file)
        {
            int idtoupdate = id;
            action article0 = new action();
            article0 = actionService.GetById(id);
           // List<SelectListItem> type = new List<SelectListItem>();
            if (Request.HttpMethod == "POST" && id != 0 && actionmodel != null)
            {
               // string path = "";
                action article = new action();
                article.idAction = idtoupdate;

                article.discriptionAction = actionmodel.discriptionAction;
                article.titreAction = actionmodel.titreAction;
                article.dateDebutAction = actionmodel.dateDebutAction;
                article.dateFinAction = actionmodel.dateFinAction;







            }
            return RedirectToAction("DisplayArticle");
                 }
    }

}