namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedForeignKeyFromSubjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentModelSubjectModels", "StudentModel_Id", "dbo.StudentMaster");
            DropForeignKey("dbo.StudentModelSubjectModels", "SubjectModel_Id", "dbo.SubjectMaster");
            DropIndex("dbo.StudentModelSubjectModels", new[] { "StudentModel_Id" });
            DropIndex("dbo.StudentModelSubjectModels", new[] { "SubjectModel_Id" });
            
            DropColumn("dbo.StudentMaster", "Subject_Id");
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentModelSubjectModels",
                c => new
                    {
                        StudentModel_Id = c.Int(nullable: false),
                        SubjectModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentModel_Id, t.SubjectModel_Id });
            
            AddColumn("dbo.StudentMaster", "Subject_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentMaster", "SubjectModel_Id", "dbo.SubjectMaster");
            DropIndex("dbo.StudentMaster", new[] { "SubjectModel_Id" });
            DropColumn("dbo.StudentMaster", "SubjectModel_Id");
            CreateIndex("dbo.StudentModelSubjectModels", "SubjectModel_Id");
            CreateIndex("dbo.StudentModelSubjectModels", "StudentModel_Id");
            AddForeignKey("dbo.StudentModelSubjectModels", "SubjectModel_Id", "dbo.SubjectMaster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentModelSubjectModels", "StudentModel_Id", "dbo.StudentMaster", "Id", cascadeDelete: true);
        }
    }
}
