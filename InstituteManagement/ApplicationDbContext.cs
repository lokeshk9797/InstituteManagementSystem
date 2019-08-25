using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using InstituteManagement.Models;
using System.Data.Entity;

namespace InstituteManagement
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ClassModel> ClassMasterModels { get; set; }

        public DbSet<CourseModel> CourserModels { get; set; }

        public DbSet<DesignationModel> DesignationMasters { get; set; }

        public DbSet<AddressModel> AddressMasters { get; set; }

        public DbSet<ContactModel> ContactModels { get; set; }

        public DbSet<StudentModel> StudentModels { get; set; }

        public DbSet<FeesModel> FeesModels { get; set; }

        public DbSet<UserMasterModel> UserMasters { get; set; }

        public DbSet<StudentFeeDetailsModel> StudentFeeDetailsModel { get; set; }

        public DbSet<ReceivedFeeDetailsModel> ReceivedFeeDetails { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}