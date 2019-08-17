using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InstituteManagement.Models
{
    [Table("DesignationMaster")]
    
    public class DesignationModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(512)]
        public String Designation { get; set; }
        public Int64 Salary { get; set; }

    }
}