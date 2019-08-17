using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace InstituteManagement.Models
{
    [Table ("StudentMaster")]
    public class StudentModel
    {
        public int Id { get; set; }

        [Required]
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        [Required]
        public String LasttName { get; set; }
        [Required]
        
        public DateTime DateOfBirth { get; set; }
        public ClassModel Class { get; set; }
        public ICollection<SubjectModel> Subjects { get; set; }
        public String School { get; set; }
        [Required]
        [StringLength(1)]
        public char gender{ get; set; }
        public AddressModel Address { get; set; }
        public ContactModel Contact { get; set; }
        public Int64 TotalFees { get; set; }
        public Byte NoOfInstallments { get; set; }

        public DateTime DateOfAdmission { get; set; }
        public bool IsActive { get; set; }
        public bool HasPassed { get; set; }
        
    }
}