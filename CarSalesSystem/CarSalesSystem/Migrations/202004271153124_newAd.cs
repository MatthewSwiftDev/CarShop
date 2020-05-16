namespace CarSalesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newAd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Price", c => c.String());
            AlterColumn("dbo.Cars", "Mileage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Mileage", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Price", c => c.Long(nullable: false));
        }
    }
}
