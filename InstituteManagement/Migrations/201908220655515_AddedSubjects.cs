namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentModelSubjectModels",
                c => new
                    {
                        StudentModel_Id = c.Int(nullable: false),
                        SubjectModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentModel_Id, t.SubjectModel_Id })
                .ForeignKey("dbo.StudentMaster", t => t.StudentModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.SubjectMaster", t => t.SubjectModel_Id, cascadeDelete: true)
                .Index(t => t.StudentModel_Id)
                .Index(t => t.SubjectModel_Id);
            
            AddColumn("dbo.StudentMaster", "Subject_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentModelSubjectModels", "SubjectModel_Id", "dbo.SubjectMaster");
            DropForeignKey("dbo.StudentModelSubjectModels", "StudentModel_Id", "dbo.StudentMaster");
            DropIndex("dbo.StudentModelSubjectModels", new[] { "SubjectModel_Id" });
            DropIndex("dbo.StudentModelSubjectModels", new[] { "StudentModel_Id" });
            DropColumn("dbo.StudentMaster", "Subject_Id");
            DropTable("dbo.StudentModelSubjectModels");
            DropTable("dbo.SubjectMaster");
        }
    }
}
