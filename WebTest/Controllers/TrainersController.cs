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
    public class TrainersController : Controller
    {
        private TrainingContext db = new TrainingContext();
        public ActionResult Index()
        {
            var trainers = db.Trainers.Include(t => t.Account);
            return View(trainers.ToList());
        }

        public ActionResult Create()
        {
            if (Session["accountRole"].ToString() != "Admin")
            {
                return RedirectToAction("About", "Home");
            }
            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "trainerId,trainerName,trainerEmail,trainerSpecially,trainerAge,trainerAddress,accountId")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainers.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", trainer.accountId);
            return View(trainer);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", trainer.accountId);
            return View(trainer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "trainerId,trainerName,trainerEmail,trainerSpecially,trainerAge,trainerAddress,accountId")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", trainer.accountId);
            return View(trainer);
        }
        public ActionResult Delete(string id)
        {
            if (Session["accountRole"].ToString() != "Admin")
            {
                return RedirectToAction("About", "Home");
            }
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
