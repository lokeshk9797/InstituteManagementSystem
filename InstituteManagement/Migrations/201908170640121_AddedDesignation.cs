namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDesignation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DesignationMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, maxLength: 512),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DesignationMaster");
        }
    }
}
