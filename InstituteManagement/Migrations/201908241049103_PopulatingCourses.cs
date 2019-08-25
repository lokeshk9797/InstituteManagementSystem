namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingCourses : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into CourseModels (CourseName) values('Maths'),('Biology'),('Arts'),('Commerce')");
        }
        
        public override void Down()
        {
        }
    }
}
