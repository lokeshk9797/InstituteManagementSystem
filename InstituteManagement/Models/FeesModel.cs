using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstituteManagement.Models
{
    [Table("FeesMaster")]
    public class FeesModel
    {
        public int Id { get; set; }

        [ForeignKey("Class")]
        public virtual int Class_Id { get; set; }
        public virtual ClassModel Class { get; set; }
        public Int32 TotalFees { get; set; }
    }
}