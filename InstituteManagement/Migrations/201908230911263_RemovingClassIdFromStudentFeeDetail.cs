namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingClassIdFromStudentFeeDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentFeeDetails", "Class_Id", "dbo.ClassMaster");
            DropIndex("dbo.StudentFeeDetails", new[] { "Class_Id" });
            DropColumn("dbo.StudentFeeDetails", "Class_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentFeeDetails", "Class_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentFeeDetails", "Class_Id");
            AddForeignKey("dbo.StudentFeeDetails", "Class_Id", "dbo.ClassMaster", "Id", cascadeDelete: true);
        }
    }
}
