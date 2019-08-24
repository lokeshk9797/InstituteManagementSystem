namespace InstituteManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingDesignation : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into DesignationMaster (Designation,Salary) values('Teacher',40000),('Senior Teacher',50000),('Librarian',30000),('Account Manager',350000),('Clerk',20000)");
        }
        
        public override void Down()
        {
        }
    }
}
