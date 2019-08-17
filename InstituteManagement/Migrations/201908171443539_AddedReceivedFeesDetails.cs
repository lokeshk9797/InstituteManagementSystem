namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReceivedFeesDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceivedFeeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountReceived = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        Student_Id = c.Int(),
                        StudentFeeDetails_Id = c.Int(),
                        UserMaster_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentMaster", t => t.Student_Id)
                .ForeignKey("dbo.StudentFeeDetails", t => t.StudentFeeDetails_Id)
                .ForeignKey("dbo.User", t => t.UserMaster_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.StudentFeeDetails_Id)
                .Index(t => t.UserMaster_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceivedFeeDetails", "UserMaster_Id", "dbo.User");
            DropForeignKey("dbo.ReceivedFeeDetails", "StudentFeeDetails_Id", "dbo.StudentFeeDetails");
            DropForeignKey("dbo.ReceivedFeeDetails", "Student_Id", "dbo.StudentMaster");
            DropIndex("dbo.ReceivedFeeDetails", new[] { "UserMaster_Id" });
            DropIndex("dbo.ReceivedFeeDetails", new[] { "StudentFeeDetails_Id" });
            DropIndex("dbo.ReceivedFeeDetails", new[] { "Student_Id" });
            DropTable("dbo.ReceivedFeeDetails");
        }
    }
}
