namespace CarSalesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Car1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "UsersId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "UsersId", c => c.Int(nullable: false));
        }
    }
}
