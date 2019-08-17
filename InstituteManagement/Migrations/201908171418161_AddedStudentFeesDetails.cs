namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudentFeesDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentFeeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RemainingAmount = c.Int(nullable: false),
                        Fees_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeesMaster", t => t.Fees_Id)
                .ForeignKey("dbo.StudentMaster", t => t.Student_Id)
                .Index(t => t.Fees_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentFeeDetails", "Student_Id", "dbo.StudentMaster");
            DropForeignKey("dbo.StudentFeeDetails", "Fees_Id", "dbo.FeesMaster");
            DropIndex("dbo.StudentFeeDetails", new[] { "Student_Id" });
            DropIndex("dbo.StudentFeeDetails", new[] { "Fees_Id" });
            DropTable("dbo.StudentFeeDetails");
        }
    }
}
