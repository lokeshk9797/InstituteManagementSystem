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
    public class ClassController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Class
        public ActionResult Index()
        {
            return View(db.ClassMasterModels.ToList());
        }

        // GET: Class/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassModel classModel = db.ClassMasterModels.Find(id);
            if (classModel == null)
            {
                return HttpNotFound();
            }
            return View(classModel);
        }

        // GET: Class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassName")] ClassModel classModel)
        {
            if (ModelState.IsValid)
            {
                db.ClassMasterModels.Add(classModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classModel);
        }

        // GET: Class/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassModel classModel = db.ClassMasterModels.Find(id);
            if (classModel == null)
            {
                return HttpNotFound();
            }
            return View(classModel);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassName")] ClassModel classModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classModel);
        }

        // GET: Class/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassModel classModel = db.ClassMasterModels.Find(id);
            if (classModel == null)
            {
                return HttpNotFound();
            }
            return View(classModel);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassModel classModel = db.ClassMasterModels.Find(id);
            db.ClassMasterModels.Remove(classModel);
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
