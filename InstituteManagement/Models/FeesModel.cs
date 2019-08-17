using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InstituteManagement.Models
{
    [Table("FeesMaster")]
    public class FeesModel
    {
        public int Id { get; set; }
        [Required]
        public ClassModel ClassModel { get; set; }
        [Required]
        public Int32 TotalFees { get; set; }

    }
}