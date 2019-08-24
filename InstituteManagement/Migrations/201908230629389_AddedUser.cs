namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUser : DbMigration
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
                        Designation_Id = c.Int(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        IsPermanent = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Shift = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DesignationMaster", t => t.Designation_Id, cascadeDelete: true)
                .Index(t => t.Designation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Designation_Id", "dbo.DesignationMaster");
            DropIndex("dbo.User", new[] { "Designation_Id" });
            DropTable("dbo.User");
        }
    }
}
