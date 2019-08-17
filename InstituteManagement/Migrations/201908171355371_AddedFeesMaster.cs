namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFeesMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeesMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalFees = c.Int(nullable: false),
                        ClassModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassMaster", t => t.ClassModel_Id, cascadeDelete: true)
                .Index(t => t.ClassModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeesMaster", "ClassModel_Id", "dbo.ClassMaster");
            DropIndex("dbo.FeesMaster", new[] { "ClassModel_Id" });
            DropTable("dbo.FeesMaster");
        }
    }
}
