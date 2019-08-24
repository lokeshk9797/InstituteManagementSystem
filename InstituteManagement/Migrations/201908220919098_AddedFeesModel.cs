namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFeesModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeesMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Class_Id = c.Int(nullable: false),
                        TotalFees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassMaster", t => t.Class_Id, cascadeDelete: true)
                .Index(t => t.Class_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeesMaster", "Class_Id", "dbo.ClassMaster");
            DropIndex("dbo.FeesMaster", new[] { "Class_Id" });
            DropTable("dbo.FeesMaster");
        }
    }
}
