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
    public class ReceivedFeeDetailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReceivedFeeDetail
        public ActionResult Index()
        {
            var receivedFeeDetails = db.ReceivedFeeDetails.Include(r => r.StudentFeeDetails);
            return View(receivedFeeDetails.ToList());
        }

        // GET: ReceivedFeeDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceivedFeeDetailsModel receivedFeeDetailsModel = db.ReceivedFeeDetails.Find(id);
            if (receivedFeeDetailsModel == null)
            {
                return HttpNotFound();
            }
            return View(receivedFeeDetailsModel);
        }

        // GET: ReceivedFeeDetail/Create
        public ActionResult Create(StudentFeeDetailsModel studentFeeDetailsModel)
        {
            ViewBag.StudentFee_Id = new SelectList(db.StudentFeeDetailsModel, "Id", "Id");
            return View();
        }

        // POST: ReceivedFeeDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentFee_Id,AmountReceived,PaymentDate")] ReceivedFeeDetailsModel receivedFeeDetailsModel)
        {
            if (ModelState.IsValid)
            {
                db.ReceivedFeeDetails.Add(receivedFeeDetailsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentFee_Id = new SelectList(db.StudentFeeDetailsModel, "Id", "Id", receivedFeeDetailsModel.StudentFee_Id);
            return View(receivedFeeDetailsModel);
        }

        // GET: ReceivedFeeDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceivedFeeDetailsModel receivedFeeDetailsModel = db.ReceivedFeeDetails.Find(id);
            if (receivedFeeDetailsModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentFee_Id = new SelectList(db.StudentFeeDetailsModel, "Id", "Id", receivedFeeDetailsModel.StudentFee_Id);
            return View(receivedFeeDetailsModel);
        }

        // POST: ReceivedFeeDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentFee_Id,AmountReceived,PaymentDate")] ReceivedFeeDetailsModel receivedFeeDetailsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receivedFeeDetailsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentFee_Id = new SelectList(db.StudentFeeDetailsModel, "Id", "Id", receivedFeeDetailsModel.StudentFee_Id);
            return View(receivedFeeDetailsModel);
        }

        // GET: ReceivedFeeDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceivedFeeDetailsModel receivedFeeDetailsModel = db.ReceivedFeeDetails.Find(id);
            if (receivedFeeDetailsModel == null)
            {
                return HttpNotFound();
            }
            return View(receivedFeeDetailsModel);
        }

        // POST: ReceivedFeeDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceivedFeeDetailsModel receivedFeeDetailsModel = db.ReceivedFeeDetails.Find(id);
            db.ReceivedFeeDetails.Remove(receivedFeeDetailsModel);
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
