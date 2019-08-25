namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReceivedFeesDEtails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceivedFeeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentFee_Id = c.Int(nullable: false),
                        AmountReceived = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        UserMaster_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentFeeDetails", t => t.StudentFee_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserMaster_Id)
                .Index(t => t.StudentFee_Id)
                .Index(t => t.UserMaster_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceivedFeeDetails", "UserMaster_Id", "dbo.User");
            DropForeignKey("dbo.ReceivedFeeDetails", "StudentFee_Id", "dbo.StudentFeeDetails");
            DropIndex("dbo.ReceivedFeeDetails", new[] { "UserMaster_Id" });
            DropIndex("dbo.ReceivedFeeDetails", new[] { "StudentFee_Id" });
            DropTable("dbo.ReceivedFeeDetails");
        }
    }
}
