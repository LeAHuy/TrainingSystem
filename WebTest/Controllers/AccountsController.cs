using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class AccountsController : Controller
    {
        private TrainingContext db = new TrainingContext();
        public ActionResult Index()
        {
            //string acc = (string)Session["accountusername"];
            //var acc1 = db.Accounts.Where(o => o.accountUsername == acc).FirstOrDefault();
            //if (acc1.accountRole == "aaaa")
            //{
            //    return RedirectToAction("Index", "Trainers");
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
            //ViewBag.password = Session["password"];
            return View(db.Accounts.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "accountId,accountUsername,accountPassword,accountRole")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "accountId,accountUsername,accountPassword,accountRole")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        public ActionResult Delete(string id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ResetPassword(string id)
        {
            Account account = db.Accounts.Find(id);
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[8];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }
            var resultString = new String(Charsarr);
            account.accountPassword = resultString;
            Session["password"] = account.accountPassword;
            // Encrypt MD5
            db.Entry(account).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", new { su = 1 });
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "accountUsername,accountPassword")] Account account)
        {
            Account account1 = new Account();
            account1 = db.Accounts.Where(o => o.accountUsername == account.accountUsername && o.accountPassword == account.accountPassword).FirstOrDefault();
            if(account1 != null)
            {
                Session["accountUsername"] = account1.accountUsername;
                Session["accountRole"] = account1.accountRole;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
