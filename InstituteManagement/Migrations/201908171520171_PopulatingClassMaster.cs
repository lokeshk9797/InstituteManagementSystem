namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingClassMaster : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ClassMaster(Class) VALUES ('1st'),('2nd'),('3rd'),('4th'),('5th'),('6th'),('7th'),('8th'),('9th'),('10th'),('11th'),('12th')");
        }
        
        public override void Down()
        {
        }
    }
}
