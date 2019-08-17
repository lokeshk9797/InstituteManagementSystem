using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstituteManagement.Models;

namespace InstituteManagement.Controllers
{
    public class ClassController : Controller
    {
        private ApplicationDbContext _context;
        public ClassController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Class
        public ViewResult Index()
        {
            var className = _context.ClassMasterModels.ToList();
            return View(className);
        }
    }
}