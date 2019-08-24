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
    public class FeesModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FeesModels
        public ActionResult Index()
        {
            var feesModels = db.FeesModels.Include(f => f.Class);
            return View(feesModels.ToList());
        }

        // GET: FeesModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeesModel feesModel = db.FeesModels.Find(id);
            if (feesModel == null)
            {
                return HttpNotFound();
            }
            return View(feesModel);
        }

        // GET: FeesModels/Create
        public ActionResult Create()
        {
            ViewBag.Class_Id = new SelectList(db.ClassMasterModels, "Id", "ClassName");
            return View();
        }

        // POST: FeesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Class_Id,TotalFees")] FeesModel feesModel)
        {
            if (ModelState.IsValid)
            {
                db.FeesModels.Add(feesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Class_Id = new SelectList(db.ClassMasterModels, "Id", "ClassName", feesModel.Class_Id);
            return View(feesModel);
        }

        // GET: FeesModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeesModel feesModel = db.FeesModels.Find(id);
            if (feesModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_Id = new SelectList(db.ClassMasterModels, "Id", "ClassName", feesModel.Class_Id);
            return View(feesModel);
        }

        // POST: FeesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Class_Id,TotalFees")] FeesModel feesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Class_Id = new SelectList(db.ClassMasterModels, "Id", "ClassName", feesModel.Class_Id);
            return View(feesModel);
        }

        // GET: FeesModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeesModel feesModel = db.FeesModels.Find(id);
            if (feesModel == null)
            {
                return HttpNotFound();
            }
            return View(feesModel);
        }

        // POST: FeesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeesModel feesModel = db.FeesModels.Find(id);
            db.FeesModels.Remove(feesModel);
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
