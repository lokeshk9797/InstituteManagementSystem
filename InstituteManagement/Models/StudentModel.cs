using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace InstituteManagement.Models
{
    [Table("StudentMaster")]
    public class StudentModel
    {
       
        public int Id { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public String FirstName { get; set; }

        [Display(Name ="Middle Name")]
        public String MiddleName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public String LastName { get; set; }

        [Column(TypeName ="date")]
        [Display(Name ="Date Of Birth")]       
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(1)]
        public String Gender { get; set; }

        public String School { get; set; }

        [ForeignKey("Class")]
        public virtual int Class_Id { get; set; }
        public virtual ClassModel Class { get; set; }

        [ForeignKey("Address")]
        public virtual int  Address_Id { get; set; }
        public virtual AddressModel Address { get; set; }

        [ForeignKey("Course")]
        public virtual int Course_Id { get; set; }
        public virtual CourseModel Course { get; set; }

        [ForeignKey("Contact")]
        public virtual int Contact_Id { get; set; }
        public virtual ContactModel Contact { get; set; }

        //[Column(Order = 10)]
        [Display(Name ="No Of Installments")]
        public Byte NoOfInstallments { get; set; }

        //[Column(Order = 11,TypeName = "datetime2")]
        [Column( TypeName = "date")]
        public DateTime DateOfAdmission { get; set; }

        
        public bool IsActive { get; set; }

        
        public bool HasPassed { get; set; }

       




    }
}