using InstituteManagement.Models;
using InstituteManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private ApplicationDbContext _context;

       

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var student = _context.StudentModels.Include(s=>s.Class).ToList();
            return View(student);
        }

        public ActionResult StudentRegistration()
        {
            var Classes = _context.ClassMasterModels.ToList();
            var viewModel = new NewStudentViewModel
            {
                ClassModels = Classes
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(StudentModel student)
        {
            
            

            _context.StudentModels.Add(student);
            _context.SaveChanges();
            
            return RedirectToAction("Index","Student");
            
        }
    }
}