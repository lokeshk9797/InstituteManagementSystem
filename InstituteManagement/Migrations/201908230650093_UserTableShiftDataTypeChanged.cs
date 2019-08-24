namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableShiftDataTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Shift", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Shift", c => c.Byte(nullable: false));
        }
    }
}
