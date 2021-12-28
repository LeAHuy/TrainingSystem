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
    public class AdminsController : Controller
    {
        private TrainingContext db = new TrainingContext();

        public ActionResult Index()
        {
            var admins = db.Admins.Include(a => a.Account);
            return View(admins.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "adminId,adminName,adminEmail,adminSpecialty,adminAge,adminAddress,accountId")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", admin.accountId);
            return View(admin);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", admin.accountId);
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "adminId,adminName,adminEmail,adminSpecialty,adminAge,adminAddress,accountId")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", admin.accountId);
            return View(admin);
        }
        public ActionResult Delete(string id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
