namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppingSubjectMaster : DbMigration
    {
        public override void Up()
        {
            
            Sql("Drop Table StudentModelSubjectModels");
        }
        
        public override void Down()
        {
        }
    }
}
