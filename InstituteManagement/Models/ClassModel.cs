using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InstituteManagement.Models
{
    [Table("ClassMaster")]
    public class ClassModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Column("Class")]
        public String ClassName { get; set; }
        //Sql("INSERT INTO ClassMaster(Class) VALUES ('1st'),('2nd'),('3rd'),('4th'),('5th'),('6th'),('7th'),('8th'),('9th'),('10th'),('11th'),('12th')");
    }
}