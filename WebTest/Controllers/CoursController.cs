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
    public class CoursController : Controller
    {
        private TrainingContext db = new TrainingContext();

        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Category).Include(c => c.Staff).Include(c => c.Topic).Include(c => c.Trainer).Include(c => c.Trainees);
            return View(courses.ToList());
        }

        public ActionResult Create()
        {
            if (Session["accountRole"].ToString() != "Staff")
            {
                return RedirectToAction("About", "Home");
            }
            ViewBag.catId = new SelectList(db.Categories, "catId", "catName");
            ViewBag.staffId = new SelectList(db.Staffs, "staffId", "staffName");
            ViewBag.topicId = new SelectList(db.Topics, "topicId", "topicName");
            ViewBag.trainerId = new SelectList(db.Trainers, "trainerId", "trainerName");
            ViewBag.traineeId = new SelectList(db.Trainees, "traineeId", "traineeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "courseId,courseName,courseDisciption,staffId,catId,topicId,trainerId,traineeId")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(cours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }   

            ViewBag.catId = new SelectList(db.Categories, "catId", "catName", cours.catId);
            ViewBag.staffId = new SelectList(db.Staffs, "staffId", "staffName", cours.staffId);
            ViewBag.topicId = new SelectList(db.Topics, "topicId", "topicName", cours.topicId);
            ViewBag.trainerId = new SelectList(db.Trainers, "trainerId", "trainerName", cours.trainerId);
            ViewBag.traineeId = new SelectList(db.Trainees, "traineeId", "traineeName");
            return View(cours);
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
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            ViewBag.catId = new SelectList(db.Categories, "catId", "catName", cours.catId);
            ViewBag.staffId = new SelectList(db.Staffs, "staffId", "staffName", cours.staffId);
            ViewBag.topicId = new SelectList(db.Topics, "topicId", "topicName", cours.topicId);
            ViewBag.trainerId = new SelectList(db.Trainers, "trainerId", "trainerName", cours.trainerId);
            ViewBag.traineeId = new SelectList(db.Trainees, "traineeId", "traineeName", cours.traineeId);
            return View(cours);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "courseId,courseName,courseDisciption,catId,traineeId,trainerId,topicId,staffId")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catId = new SelectList(db.Categories, "catId", "catName", cours.catId);
            ViewBag.staffId = new SelectList(db.Staffs, "staffId", "staffName", cours.staffId);
            ViewBag.topicId = new SelectList(db.Topics, "topicId", "topicName", cours.topicId);
            ViewBag.trainerId = new SelectList(db.Trainers, "trainerId", "trainerName", cours.trainerId);
            ViewBag.traineeId = new SelectList(db.Trainees, "traineeId", "traineeName", cours.traineeId);
            return View(cours);
        }
        public ActionResult Delete(string id)
        {
            if (Session["accountRole"].ToString() != "Staff")
            {
                return RedirectToAction("About", "Home");
            }
            Cours cours = db.Courses.Find(id);
            db.Courses.Remove(cours);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
