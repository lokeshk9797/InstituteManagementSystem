namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentColumnCorrected : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentMaster", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.StudentMaster", "LasttName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentMaster", "LasttName", c => c.String(nullable: false));
            DropColumn("dbo.StudentMaster", "LastName");
        }
    }
}
