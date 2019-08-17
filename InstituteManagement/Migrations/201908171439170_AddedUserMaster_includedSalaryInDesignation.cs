namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserMaster_includedSalaryInDesignation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        IsPermanent = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Shift = c.Byte(nullable: false),
                        Designation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DesignationMaster", t => t.Designation_Id)
                .Index(t => t.Designation_Id);
            
            AddColumn("dbo.DesignationMaster", "Salary", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Designation_Id", "dbo.DesignationMaster");
            DropIndex("dbo.User", new[] { "Designation_Id" });
            DropColumn("dbo.DesignationMaster", "Salary");
            DropTable("dbo.User");
        }
    }
}
