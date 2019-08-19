namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeChangedinStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentMaster", "DateOfBirth", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.StudentMaster", "DateOfAdmission", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentMaster", "DateOfAdmission", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentMaster", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
