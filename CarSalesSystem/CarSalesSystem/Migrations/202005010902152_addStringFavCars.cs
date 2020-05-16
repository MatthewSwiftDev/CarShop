namespace CarSalesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStringFavCars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FavCars", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "FavCars");
        }
    }
}
