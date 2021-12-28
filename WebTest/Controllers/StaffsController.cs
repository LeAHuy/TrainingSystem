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
    public class StaffsController : Controller
    {
        private TrainingContext db = new TrainingContext();

        public ActionResult Index()
        {
            var staffs = db.Staffs.Include(s => s.Account);
            return View(staffs.ToList());
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
        public ActionResult Create([Bind(Include = "staffId,staffName,staffEmail,staffAge,staffAddress,accountId")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", staff.accountId);
            return View(staff);
        }

        public ActionResult Edit(string id)
        {
            if (Session["accountRole"].ToString() != "Admin")
            {
                return RedirectToAction("About", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", staff.accountId);
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "staffId,staffName,staffEmail,staffAge,staffAddress,accountId")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountId = new SelectList(db.Accounts, "accountId", "accountUsername", staff.accountId);
            return View(staff);
        }
        public ActionResult Delete(string id)
        {
            if (Session["accountRole"].ToString() != "Admin")
            {
                return RedirectToAction("About", "Home");
            }
            Staff staff = db.Staffs.Find(id);
            db.Staffs.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
