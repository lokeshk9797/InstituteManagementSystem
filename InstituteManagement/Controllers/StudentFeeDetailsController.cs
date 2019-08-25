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
    public class StudentFeeDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentFeeDetails
        public ActionResult Index()
        {
            var studentFeeDetailsModel = db.StudentFeeDetailsModel.Include(s => s.Fees).Include(s => s.Student);
            return View(studentFeeDetailsModel.ToList());
        }

        // GET: StudentFeeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentFeeDetailsModel studentFeeDetailsModel = db.StudentFeeDetailsModel.Find(id);
            if (studentFeeDetailsModel == null)
            {
                return HttpNotFound();
            }
            return View(studentFeeDetailsModel);
        }

        // GET: StudentFeeDetails/Create
        public ActionResult Create()
        {
            ViewBag.Fees_Id = new SelectList(db.FeesModels, "Id", "Id");
            ViewBag.Student_Id = new SelectList(db.StudentModels, "Id", "FirstName");
            return View();
        }

        // POST: StudentFeeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Student_Id,Fees_Id,TotalFees,RemainingAmount")] StudentFeeDetailsModel studentFeeDetailsModel)
        {
            return RedirectToAction("Create","ReceivedFeeDetail",studentFeeDetailsModel);

            //if (ModelState.IsValid)
            //{
            //    db.StudentFeeDetailsModel.Add(studentFeeDetailsModel);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.Fees_Id = new SelectList(db.FeesModels, "Id", "Id", studentFeeDetailsModel.Fees_Id);
            //ViewBag.Student_Id = new SelectList(db.StudentModels, "Id", "FirstName", studentFeeDetailsModel.Student_Id);
            //return View(studentFeeDetailsModel);
        }

        // GET: StudentFeeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentFeeDetailsModel studentFeeDetailsModel = db.StudentFeeDetailsModel.Find(id);
            if (studentFeeDetailsModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fees_Id = new SelectList(db.FeesModels, "Id", "Id", studentFeeDetailsModel.Fees_Id);
            ViewBag.Student_Id = new SelectList(db.StudentModels, "Id", "FirstName", studentFeeDetailsModel.Student_Id);
            return View(studentFeeDetailsModel);
        }

        // POST: StudentFeeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Student_Id,Fees_Id,TotalFees,RemainingAmount")] StudentFeeDetailsModel studentFeeDetailsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentFeeDetailsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fees_Id = new SelectList(db.FeesModels, "Id", "Id", studentFeeDetailsModel.Fees_Id);
            ViewBag.Student_Id = new SelectList(db.StudentModels, "Id", "FirstName", studentFeeDetailsModel.Student_Id);
            return View(studentFeeDetailsModel);
        }

        // GET: StudentFeeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentFeeDetailsModel studentFeeDetailsModel = db.StudentFeeDetailsModel.Find(id);
            if (studentFeeDetailsModel == null)
            {
                return HttpNotFound();
            }
            return View(studentFeeDetailsModel);
        }

        // POST: StudentFeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentFeeDetailsModel studentFeeDetailsModel = db.StudentFeeDetailsModel.Find(id);
            db.StudentFeeDetailsModel.Remove(studentFeeDetailsModel);
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
