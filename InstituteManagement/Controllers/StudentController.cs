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
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student
        public ActionResult Index()
        {
            var studentModels = db.StudentModels.Include(s => s.Address).Include(s => s.Class).Include(s => s.Contact).Include(s => s.Course);
            return View(studentModels.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel studentModel = db.StudentModels.Find(id);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.Address_Id = new SelectList(db.AddressMasters, "Id", "Address");
            ViewBag.Class_Id = new SelectList(db.ClassMasterModels, "Id", "ClassName");
            ViewBag.Contact_Id = new SelectList(db.ContactModels, "Id", "MobileNumber");
            ViewBag.Course_Id = new SelectList(db.CourserModels, "Id", "CourseName");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,DateOfBirth,Gender,School,Class_Id,Address,Course_Id,Contact,NoOfInstallments,DateOfAdmission,IsActive,HasPassed")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                studentModel.IsActive = true;
                studentModel.HasPassed = false;
                db.StudentModels.Add(studentModel);
                db.SaveChanges();
                StudentFeeDetailsModel studentFeeDetailsModel = new StudentFeeDetailsModel();
                studentFeeDetailsModel.Student = studentModel;
                studentFeeDetailsModel.Fees = db.FeesModels.Include(s => s.Class).Where(s => s.Class_Id == studentModel.Class_Id).FirstOrDefault();
                studentFeeDetailsModel.TotalFees = db.FeesModels.Include(s => s.Class).Where(s => s.Class_Id == studentModel.Class_Id).Select(s => s.TotalFees).FirstOrDefault();
                db.StudentFeeDetailsModel.Add(studentFeeDetailsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Address_Id = new SelectList(db.AddressMasters, "Id", "Address", studentModel.Address_Id);
            ViewBag.Class_Id = new SelectList(db.ClassMasterModels, "Id", "ClassName", studentModel.Class_Id);
            ViewBag.Contact_Id = new SelectList(db.ContactModels, "Id", "MobileNumber", studentModel.Contact_Id);
            ViewBag.Course_Id = new SelectList(db.CourserModels, "Id", "CourseName", studentModel.Course_Id);
            return View(studentModel);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel studentModel = db.StudentModels.Find(id);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Address_Id = new SelectList(db.AddressMasters, "Id", "Address", studentModel.Address_Id);
            ViewBag.Class_Id = new SelectList(db.ClassMasterModels, "Id", "ClassName", studentModel.Class_Id);
            ViewBag.Contact_Id = new SelectList(db.ContactModels, "Id", "MobileNumber", studentModel.Contact_Id);
            ViewBag.Course_Id = new SelectList(db.CourserModels, "Id", "CourseName", studentModel.Course_Id);
            return View(studentModel);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,DateOfBirth,Gender,School,Class_Id,Address_Id,Course_Id,Contact_Id,NoOfInstallments,DateOfAdmission,IsActive,HasPassed")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Address_Id = new SelectList(db.AddressMasters, "Id", "Address", studentModel.Address_Id);
            ViewBag.Class_Id = new SelectList(db.ClassMasterModels, "Id", "ClassName", studentModel.Class_Id);
            ViewBag.Contact_Id = new SelectList(db.ContactModels, "Id", "MobileNumber", studentModel.Contact_Id);
            ViewBag.Course_Id = new SelectList(db.CourserModels, "Id", "CourseName", studentModel.Course_Id);
            return View(studentModel);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel studentModel = db.StudentModels.Find(id);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            StudentModel studentModel = db.StudentModels.Find(id);
            AddressModel addressModel = db.AddressMasters.Find(studentModel.Address_Id);
            ContactModel contactModel = db.ContactModels.Find(studentModel.Contact_Id);
            StudentFeeDetailsModel studentFeeDetailsModel = db.StudentFeeDetailsModel.Where(s => s.Student_Id == studentModel.Id).FirstOrDefault();
            db.StudentModels.Remove(studentModel);
            db.ContactModels.Remove(contactModel);
            db.AddressMasters.Remove(addressModel);
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
