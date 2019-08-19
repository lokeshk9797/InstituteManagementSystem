namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentandClassModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentMaster", "Gender", c => c.String(nullable: false, maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentMaster", "Gender");
        }
    }
}
