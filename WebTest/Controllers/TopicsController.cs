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
    public class TopicsController : Controller
    {
        private TrainingContext db = new TrainingContext();
        public ActionResult Index()
        {
            return View(db.Topics.ToList());
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
        public ActionResult Create([Bind(Include = "topicId,topicName,topicDisciption")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topic);
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
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "topicId,topicName,topicDisciption")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }
        public ActionResult Delete(string id)
        {
            if (Session["accountRole"].ToString() != "Staff")
            {
                return RedirectToAction("About", "Home");
            }
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
