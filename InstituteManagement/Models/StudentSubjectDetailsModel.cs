using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstituteManagement.Models
{
    [Table("StudentSubjectDetail")]
    public class StudentSubjectDetailsModel
    {
        public int Id { get; set; }
        
        public StudentModel Student { get; set; }
        public SubjectModel Subject { get; set; }
    }
}