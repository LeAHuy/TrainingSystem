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
    public class TraineesController : Controller
    {
        private TrainingContext db = new TrainingContext();

        public ActionResult Index()
        {
            var trainees = db.Trainees.Include(t => t.Account);
            return View(trainees.ToList());
        }

        public ActionResult Create()
        {
            if (Session["accountRole"].ToString() != "Staff")
            {
                return RedirectToAction("About", "Home");
            }
            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "traineeId,traineeName,traineeEmail,traineeAge,traineeDoB,traineeEducation,accountId")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Trainees.Add(trainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", trainee.accountId);
            return View(trainee);
        }

        public ActionResult Edit(string id)
        {
            if (Session["accountRole"].ToString() != "Staff")
            {
                return RedirectToAction("About", "Home");
            }
            if (Session["accountRole"].ToString() != "Staff")
            {
                return RedirectToAction("About", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", trainee.accountId);
            return View(trainee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "traineeId,traineeName,traineeEmail,traineeAge,traineeDoB,traineeEducation,accountId")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", trainee.accountId);
            return View(trainee);
        }

        public ActionResult Delete(string id)
        {
            if (Session["accountRole"].ToString() != "Staff")
            {
                return RedirectToAction("About", "Home");
            }
            Trainee trainee = db.Trainees.Find(id);
            db.Trainees.Remove(trainee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
