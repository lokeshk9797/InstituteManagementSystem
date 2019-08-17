namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LasttName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        School = c.String(),
                        NoOfInstallments = c.Byte(nullable: false),
                        DateOfAdmission = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        HasPassed = c.Boolean(nullable: false),
                        Address_Id = c.Int(),
                        Class_Id = c.Int(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressMaster", t => t.Address_Id)
                .ForeignKey("dbo.ClassMaster", t => t.Class_Id)
                .ForeignKey("dbo.ContactMaster", t => t.Contact_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Class_Id)
                .Index(t => t.Contact_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentMaster", "Contact_Id", "dbo.ContactMaster");
            DropForeignKey("dbo.StudentMaster", "Class_Id", "dbo.ClassMaster");
            DropForeignKey("dbo.StudentMaster", "Address_Id", "dbo.AddressMaster");
            DropIndex("dbo.StudentMaster", new[] { "Contact_Id" });
            DropIndex("dbo.StudentMaster", new[] { "Class_Id" });
            DropIndex("dbo.StudentMaster", new[] { "Address_Id" });
            DropTable("dbo.StudentMaster");
        }
    }
}
