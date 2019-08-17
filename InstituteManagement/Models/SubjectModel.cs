using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstituteManagement.Models
{
    [Table("SubjectMaster")]
    public class SubjectModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String SubjectName { get; set; }
    }
}