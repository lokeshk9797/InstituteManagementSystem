namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCoursetoStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentMaster", "Course_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentMaster", "Course_Id");
            AddForeignKey("dbo.StudentMaster", "Course_Id", "dbo.CourseModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentMaster", "Course_Id", "dbo.CourseModels");
            DropIndex("dbo.StudentMaster", new[] { "Course_Id" });
            DropColumn("dbo.StudentMaster", "Course_Id");
        }
    }
}
