using JobConsume.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using volunteer.domaine.entities;
using volunteer.Service;

namespace JobConsume.Areas.Administrator.Controllers
{
    public class DonationController : Controller
    {

        DonationService sc = new DonationService();



        public ActionResult Index()
        {
            List<donation> dons = new List<donation>();
            foreach (var item in sc.GetAll())
            {
                donation dn = new donation();
                dn.id = item.id;
                dn.lieuDonation = item.lieuDonation;
                dn.TitreDonation = item.TitreDonation;
                dn.TypeDonation = item.TypeDonation;
                dn.image = item.image;
                dn.dateajout = item.dateajout;
                dn.disponibilite = item.disponibilite;
               
                dons.Add(dn);

            }



            return View(dons);
        }
        public ActionResult IndexAdmin()
        {
            List<donation> dons = new List<donation>();
            foreach (var item in sc.GetAll())
            {
                donation dn = new donation();
                dn.id = item.id;
                dn.lieuDonation = item.lieuDonation;
                dn.TitreDonation = item.TitreDonation;
                dn.TypeDonation = item.TypeDonation;
                dn.image = item.image;
                dn.dateajout = item.dateajout;
                dn.disponibilite = item.disponibilite;

                dons.Add(dn);

            }



            return View(dons);
        }
        // GET: Donation/Details/5
        public ActionResult Details(int id)
        {
            donation acc = sc.GetById(id);
            DonationMvc accomodation = new DonationMvc
            {
                id = acc.id,
                lieuDonation = acc.lieuDonation,
                TitreDonation = acc.TitreDonation,
                TypeDonation = acc.TypeDonation,
                image = acc.image,
                dateajout =acc.dateajout,
                disponibilite =acc.disponibilite,
                email =acc.email
            };
            return View(accomodation);

        }


        // GET: Donation/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Donation/Create
        [HttpPost]
        public ActionResult Create(DonationMvc donati, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid || image == null || image.ContentLength == 0)
            {
                RedirectToAction("Create");
            }

            donation don = new donation();
            don.lieuDonation = donati.lieuDonation;
            don.TitreDonation = donati.TitreDonation;
            don.TypeDonation = donati.TypeDonation;
            don.image = image.FileName;
            don.id = donati.id;
            don.dateajout = donati.dateajout;
            don.disponibilite = donati.disponibilite;
            don.email = donati.email;


            sc.Add(don);
            sc.Commit();
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), image.FileName);
            image.SaveAs(path);


            return RedirectToAction("Index");

        }

        // GET: Donation/Edit/5
        public ActionResult Edit(int id)
        {
            donation acc = sc.GetById(id);
            DonationMvc accmodation = new DonationMvc
            {
                id = acc.id,
                TitreDonation = acc.TitreDonation,
                TypeDonation = acc.TypeDonation,
                lieuDonation = acc.lieuDonation,
                image = acc.image,
                email = acc.email,
                disponibilite = acc.disponibilite,
                dateajout = acc.dateajout,
                


            };
            return View(accmodation);
        }

        // POST: Donation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DonationMvc DMvc)
        {
            donation acc = sc.GetById(id);
            acc.id = DMvc.id;
            acc.lieuDonation = DMvc.lieuDonation;
            acc.TitreDonation = DMvc.TitreDonation;
            acc.TypeDonation = DMvc.TypeDonation;
            acc.image = DMvc.image;
            acc.dateajout = DMvc.dateajout;
            acc.disponibilite = DMvc.disponibilite;
            acc.email = acc.email;
            if (ModelState.IsValid)
            {
                sc.Update(acc);
                sc.Commit();
                return RedirectToAction("Index");
            }

            return View();

        }

        // GET: Donation/Delete/5
        public ActionResult Delete(int id)
        {
            donation acc = sc.GetById(id);
            DonationMvc accomodation = new DonationMvc
            {
                lieuDonation = acc.lieuDonation,
                TitreDonation = acc.TitreDonation,
                TypeDonation = acc.TypeDonation,
                email = acc.email,
                

            };
            return View(accomodation);

        }

        // POST: Donation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                donation acc = sc.GetById(id);
                sc.Delete(acc);
                sc.Commit();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Confirm(int id, DonationMvc res)
        {
           

                donation acc = sc.GetById(id);
            try
            {

                
                    acc.id = res.id;
                    acc.disponibilite = "indisponibe";
                    sc.Update(acc);
                    sc.Commit();
                    sc.email("Booking Confirmation",
                       "Your reservation has been confirmed ," +
                        "please Connect to your account and Click on My Reservations , Download the Confirmation receipt in order to pay for your reservation for the donation "
                       );
                    // ScriptManager.RegisterClientScriptBlock(, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                    //      return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");

                    return RedirectToAction("Confirm");
           
            }
            catch(Exception e)
            {

            }

            return View("Confirm");           
        }
        public ActionResult sortedPrice()
        {
            List<donation> list = new List<donation>();
            foreach (var item in sc.sortedByDate())
            {
                donation dn = new donation();
                dn.id = item.id;
                dn.lieuDonation = item.lieuDonation;
                dn.TitreDonation = item.TitreDonation;
                dn.TypeDonation = item.TypeDonation;
                dn.image = item.image;
                dn.dateajout = item.dateajout;
                dn.disponibilite = item.disponibilite;
                list.Add(dn);

            }
            //var list = SC.GetAll();
            return View(list);

        }
        public ActionResult DonateDispo()
        {
            List<donation> list = new List<donation>();
            foreach (var item in sc.donDispo())
            {
                donation dn = new donation();
                dn.id = item.id;
                dn.lieuDonation = item.lieuDonation;
                dn.TitreDonation = item.TitreDonation;
                dn.TypeDonation = item.TypeDonation;
                dn.image = item.image;
                dn.dateajout = item.dateajout;
                dn.disponibilite = item.disponibilite;
                list.Add(dn);

            }
            //var list = SC.GetAll();
            return View(list);

        }
    }
}
