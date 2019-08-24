namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudentFeeDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentFeeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Student_Id = c.Int(nullable: false),
                        Class_Id = c.Int(nullable: false),
                        Fees_Id = c.Int(nullable: false),
                        TotalFees = c.Int(nullable: false),
                        RemainingAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassMaster", t => t.Class_Id, cascadeDelete: true)
                .ForeignKey("dbo.FeesMaster", t => t.Fees_Id)
                .ForeignKey("dbo.StudentMaster", t => t.Student_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Class_Id)
                .Index(t => t.Fees_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentFeeDetails", "Student_Id", "dbo.StudentMaster");
            DropForeignKey("dbo.StudentFeeDetails", "Fees_Id", "dbo.FeesMaster");
            DropForeignKey("dbo.StudentFeeDetails", "Class_Id", "dbo.ClassMaster");
            DropIndex("dbo.StudentFeeDetails", new[] { "Fees_Id" });
            DropIndex("dbo.StudentFeeDetails", new[] { "Class_Id" });
            DropIndex("dbo.StudentFeeDetails", new[] { "Student_Id" });
            DropTable("dbo.StudentFeeDetails");
        }
    }
}
