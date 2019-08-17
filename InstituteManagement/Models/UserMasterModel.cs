using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstituteManagement.Models
{
    [Table("User")]
    public class UserMasterModel
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public DesignationModel Designation { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool IsPermanent { get; set; }
        public bool IsActive { get; set; }
        public Byte Shift { get; set; }
    }
}