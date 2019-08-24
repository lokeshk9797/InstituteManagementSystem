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

        [ForeignKey("Student")]
        public virtual int Student_Id { get; set; }
        public virtual StudentModel Student { get; set; }

        [ForeignKey("Fees")]
        public virtual int Fees_Id { get; set; }
        public virtual FeesModel Fees { get; set; }

        public Int32 TotalFees { get; set; }

        public Int32 RemainingAmount { get; set; }
    }
}