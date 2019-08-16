using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstituteManagement.Models;

namespace InstituteManagement.Controllers
{
    public class ClassMasterController : Controller
    {
        // GET: ClassMaster
        public ActionResult ShowClass()
        {
            var obj = new ClassModel() {  ClassName="1st" };
            //return View(obj);
            return Content("Hello   ");
        }

        public ActionResult Edit( int id)
        {
            return Content("Id =" + id);

        }
    }
}