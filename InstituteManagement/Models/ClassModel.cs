﻿using System;
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
        

    }
}