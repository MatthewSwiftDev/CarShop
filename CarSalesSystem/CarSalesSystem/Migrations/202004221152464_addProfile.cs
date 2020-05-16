namespace CarSalesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "PhoneNumber");
        }
    }
}
