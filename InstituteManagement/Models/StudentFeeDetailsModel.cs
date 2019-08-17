using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstituteManagement.Models
{
    [Table("StudentFeeDetails")]
    public class StudentFeeDetailsModel
    {
        public int Id { get; set; }
        public StudentModel Student { get; set; }
        public FeesModel Fees { get; set; }
        public Int32 RemainingAmount { get; set; }
    }
}