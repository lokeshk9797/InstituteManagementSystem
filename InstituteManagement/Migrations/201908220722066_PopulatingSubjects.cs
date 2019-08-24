namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingSubjects : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into SubjectMaster(SubjectName) Values ('English'),('Hindi'),('Maths'),('Physics'),('Chemistry')");
        }
        
        public override void Down()
        {
        }
    }
}
