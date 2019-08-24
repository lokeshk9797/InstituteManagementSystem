namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentMaster", "SubjectModel_Id", "dbo.SubjectMaster");
            DropIndex("dbo.StudentMaster", new[] { "SubjectModel_Id" });
            CreateTable(
                "dbo.CourseModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubjectMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StudentMaster", "SubjectModel_Id", c => c.Int());
            DropTable("dbo.CourseModels");
            CreateIndex("dbo.StudentMaster", "SubjectModel_Id");
            AddForeignKey("dbo.StudentMaster", "SubjectModel_Id", "dbo.SubjectMaster", "Id");
        }
    }
}
