using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantEFDbFirstApproach.Models;

namespace RestaurantEFDbFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        WFADotNetEntities db = new WFADotNetEntities();
        // GET: Home
        public ActionResult Index(string search="")
        {
            ViewBag.Search = search;
            
            var Rest=db.RestaurantTables.Where(r=>r.Name.Contains(search)).ToList();
            return View(Rest);
        }

        public ActionResult Details(int id)
        {
            RestaurantTable rest = db.RestaurantTables.Where(r => r.RestaurantId == id).FirstOrDefault();
            return View(rest);
        }

        public ActionResult Create()
        {
            db.RestaurantTables.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantTable restab)
        {
            db.RestaurantTables.Add(restab);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var restToUpdate = db.RestaurantTables.Where(e => e.RestaurantId == id).FirstOrDefault();
            return View(restToUpdate);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantTable resttab)
        {
            var updatedrest = db.RestaurantTables.Where(e => e.RestaurantId == resttab.RestaurantId).FirstOrDefault();
            updatedrest.Name = resttab.Name;
            updatedrest.Cusine = resttab.Cusine;
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deleteRest = db.RestaurantTables.Where(e => e.RestaurantId == id).FirstOrDefault();
            return View(deleteRest);
        }

        [HttpPost]
        public ActionResult Delete(int id, RestaurantTable resttab)
        {
            var deleteRest = db.RestaurantTables.Where(e => e.RestaurantId == id).FirstOrDefault();
            db.RestaurantTables.Remove(deleteRest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}