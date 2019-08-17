using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace InstituteManagement.Models
{
    [Table("ContactMaster")]
    public class ContactModel
    {
        public int Id { get; set; }
        [Required]
        public String MobileNumber { get; set; }
        public String PhoneNumber { get; set; }
    }
}