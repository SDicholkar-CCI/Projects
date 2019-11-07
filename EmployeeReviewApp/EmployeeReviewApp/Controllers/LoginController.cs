using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeReviewApp.DAL;
using EmployeeReviewApp.Models;
using EmployeeReviewApp.Methods;
using System.Web.Security;

namespace EmployeeReviewApp.Controllers
{
    public class LoginController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Login
        public IEmployeeReview empReview;
        public LoginController()
        {
            empReview = new EmployeeReview();
        }

        public ActionResult ClearCookie()
        {
            ViewBag.showSignOutButton = false;
            FormsAuthentication.SignOut();
            HttpContext.Session.Abandon();
            return View("Index");
        }
        public ActionResult Index()
        {
            ViewBag.showSignOutButton = false;
            return View();
        }
        [HttpPost]
        public ActionResult AuthorizeUser(User user)
        {
            int userId = empReview.CheckForValidUser(user);
            var ratingExistForEmployee = empReview.RatingExistsForEmployee(userId);
            if(userId == 0)
            {
                ViewBag.showSignOutButton = false;
                ViewBag.userNotFound = "User not found";
                return View("Index");
            }
            else if(ratingExistForEmployee && userId > 0)
            {
                FormsAuthentication.SetAuthCookie(userId.ToString(),false);
                //return Redirect(FormsAuthentication.GetRedirectUrl(userId.ToString(), false));
                return RedirectToAction("DisplayDeveloperAndTechnicalSkill", "EmployeeDeveloperTechnicalSkill", new { userId = userId });
            }
            else
            {
                FormsAuthentication.SetAuthCookie(userId.ToString(), false);
                return RedirectToAction("Index", "EmployeeDeveloperTechnicalSkill", new { hdnCount = 0,userId = userId});
            }
            
        }

        // GET: Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,Designation")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,Designation")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
