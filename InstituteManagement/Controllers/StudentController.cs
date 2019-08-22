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
            var studentModels = db.StudentModels.Include(s => s.Address).Include(s => s.Class).Include(s => s.Contact);
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
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,DateOfBirth,Gender,School,Class_Id,Address,Contact,NoOfInstallments,DateOfAdmission,IsActive,HasPassed")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                //AddressModel address = new AddressModel { Address = "Mihan" };
                //ContactModel contact = new ContactModel { MobileNumber = "0909090909" };
                //studentModel.Address = address;
                //studentModel.Contact = contact;
                db.StudentModels.Add(studentModel);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Address_Id = new SelectList(db.AddressMasters, "Id", "Address", studentModel.Address_Id);
            ViewBag.Class_Id = new SelectList(db.ClassMasterModels, "Id", "ClassName", studentModel.Class_Id);
            ViewBag.Contact_Id = new SelectList(db.ContactModels, "Id", "MobileNumber", studentModel.Contact_Id);
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
            return View(studentModel);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,DateOfBirth,Gender,School,Class_Id,Address_Id,Contact_Id,NoOfInstallments,DateOfAdmission,IsActive,HasPassed")] StudentModel studentModel)
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
            db.StudentModels.Remove(studentModel);
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
