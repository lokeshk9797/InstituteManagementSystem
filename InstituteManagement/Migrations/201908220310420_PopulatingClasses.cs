namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingClasses : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into ClassMaster (Class) Values ('1'),('2'),('3'),('4'),('5'),('6'),('7'),('8'),('9'),('10'),('11'),('12')");
        }
        
        public override void Down()
        {
        }
    }
}
