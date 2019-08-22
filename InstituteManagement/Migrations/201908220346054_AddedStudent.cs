namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudent : DbMigration
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
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Gender = c.String(nullable: false, maxLength: 1),
                        School = c.String(),
                        Class_Id = c.Int(nullable: false),
                        Address_Id = c.Int(nullable: false),
                        Contact_Id = c.Int(nullable: false),
                        NoOfInstallments = c.Byte(nullable: false),
                        DateOfAdmission = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        HasPassed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressMaster", t => t.Address_Id, cascadeDelete: true)
                .ForeignKey("dbo.ClassMaster", t => t.Class_Id, cascadeDelete: true)
                .ForeignKey("dbo.ContactMaster", t => t.Contact_Id, cascadeDelete: true)
                .Index(t => t.Class_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Contact_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentMaster", "Contact_Id", "dbo.ContactMaster");
            DropForeignKey("dbo.StudentMaster", "Class_Id", "dbo.ClassMaster");
            DropForeignKey("dbo.StudentMaster", "Address_Id", "dbo.AddressMaster");
            DropIndex("dbo.StudentMaster", new[] { "Contact_Id" });
            DropIndex("dbo.StudentMaster", new[] { "Address_Id" });
            DropIndex("dbo.StudentMaster", new[] { "Class_Id" });
            DropTable("dbo.StudentMaster");
        }
    }
}
