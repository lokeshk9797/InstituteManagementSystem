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
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(Order =1)]
        [Display(Name ="First Name")]
        public String FirstName { get; set; }

        [Display(Name ="Middle Name")]
        [Column(Order = 2)]
        public String MiddleName { get; set; }

        [Required]
        [Column(Order = 3)]
        [Display(Name ="Last Name")]
        public String LastName { get; set; }

        [Column(Order = 4,TypeName ="datetime2")]
        [Display(Name ="Date Of Birth")]
       
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(1)]
        [Column(Order = 5)]
        public String Gender { get; set; }

        [Column(Order = 6)]
        public String School { get; set; }

        [Column(Order = 7)]
        public int Class_Id;
        public ClassModel Class { get; set; }

        [Column(Order = 8)]
        public AddressModel Address { get; set; }

        [Column(Order = 9)]
        public ContactModel Contact { get; set; }


        [Column(Order = 10)]
        [Display(Name ="No Of Installments")]
        public Byte NoOfInstallments { get; set; }

        [Column(Order =11,TypeName = "datetime2")]
        public DateTime DateOfAdmission { get; set; }

        [Column(Order = 12)]
        public bool IsActive { get; set; }

        [Column(Order = 13)]
        public bool HasPassed { get; set; }

        
    }
}