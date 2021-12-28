using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class CategoriesController : Controller
    {
        private TrainingContext db = new TrainingContext();

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Create()
        {
            if (Session["accountRole"].ToString() != "Staff")
            {
                return RedirectToAction("About", "Home");
            }    
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "catId,catName,catDisciption")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public ActionResult Edit(string id)
        {
            if (Session["accountRole"].ToString() != "Staff")
            {
                return RedirectToAction("About", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "catId,catName,catDisciption")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public ActionResult Delete(string id)
        {
            if (Session["accountRole"].ToString() != "Staff")
            {
                return RedirectToAction("About", "Home");
            }
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
