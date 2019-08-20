using InstituteManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteManagement.ViewModel
{
    public class NewStudentViewModel
    {
        public IEnumerable<ClassModel> ClassModels { get; set; }
        public ClassModel CLassForStoring { get; set; }
        public StudentModel Student { get; set; }

    }
}