using pidevDomain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webpidev.Controllers
{
    public class ReportController : Controller
    {
        ReportService rs = null;
        // GET: Report
        public ActionResult ReportDetails(int id )
        {
            Report report = null;
            rs = new ReportService();
            report = rs.GetById(id);
            ViewBag.id = report.Id;
            ViewBag.mail = report.mail;
            ViewBag.sujet = report.Sujet;
            ViewBag.DDB = report.DateBanneBegin;
            ViewBag.DEB = report.DateBanneEnd;



            return View();
        }
    }
}