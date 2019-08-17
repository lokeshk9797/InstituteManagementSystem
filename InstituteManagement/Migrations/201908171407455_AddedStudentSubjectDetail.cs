namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudentSubjectDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentSubjectDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Student_Id = c.Int(),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentMaster", t => t.Student_Id)
                .ForeignKey("dbo.SubjectMaster", t => t.Subject_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Subject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubjectDetail", "Subject_Id", "dbo.SubjectMaster");
            DropForeignKey("dbo.StudentSubjectDetail", "Student_Id", "dbo.StudentMaster");
            DropIndex("dbo.StudentSubjectDetail", new[] { "Subject_Id" });
            DropIndex("dbo.StudentSubjectDetail", new[] { "Student_Id" });
            DropTable("dbo.StudentSubjectDetail");
        }
    }
}
