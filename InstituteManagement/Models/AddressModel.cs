using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InstituteManagement.Models
{
    [Table("AddressMaster")]
    public class AddressModel
    {
        public int Id { get; set; }
        [Required]
        
        public String Address { get; set; }
    }
}