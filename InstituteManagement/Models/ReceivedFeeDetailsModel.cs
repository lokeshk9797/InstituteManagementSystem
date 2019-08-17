using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstituteManagement.Models
{
    [Table("ReceivedFeeDetails")]
    public class ReceivedFeeDetailsModel
    {
        public int Id { get; set; }
        public StudentModel Student { get; set; }
        public StudentFeeDetailsModel StudentFeeDetails { get; set; }
        public Int32 AmountReceived { get; set; }
        public DateTime PaymentDate { get; set; }
        public UserMasterModel UserMaster { get; set; }
    }
}