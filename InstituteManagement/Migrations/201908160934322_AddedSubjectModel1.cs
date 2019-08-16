namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubjectModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectMasterModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubjectMasterModels");
        }
    }
}
