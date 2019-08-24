using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteManagement;
using InstituteManagement.Models;

namespace InstituteManagement.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {
            var userMasters = db.UserMasters.Include(u => u.Designation);
            return View(userMasters.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMasterModel userMasterModel = db.UserMasters.Find(id);
            if (userMasterModel == null)
            {
                return HttpNotFound();
            }
            return View(userMasterModel);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.Designation_Id = new SelectList(db.DesignationMasters, "Id", "Designation");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,Designation_Id,JoiningDate,IsPermanent,IsActive,Shift")] UserMasterModel userMasterModel)
        {
            if (ModelState.IsValid)
            {
                db.UserMasters.Add(userMasterModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Designation_Id = new SelectList(db.DesignationMasters, "Id", "Designation", userMasterModel.Designation_Id);
            return View(userMasterModel);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMasterModel userMasterModel = db.UserMasters.Find(id);
            if (userMasterModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Designation_Id = new SelectList(db.DesignationMasters, "Id", "Designation", userMasterModel.Designation_Id);
            return View(userMasterModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,Designation_Id,JoiningDate,IsPermanent,IsActive,Shift")] UserMasterModel userMasterModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMasterModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Designation_Id = new SelectList(db.DesignationMasters, "Id", "Designation", userMasterModel.Designation_Id);
            return View(userMasterModel);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMasterModel userMasterModel = db.UserMasters.Find(id);
            if (userMasterModel == null)
            {
                return HttpNotFound();
            }
            return View(userMasterModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMasterModel userMasterModel = db.UserMasters.Find(id);
            db.UserMasters.Remove(userMasterModel);
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
