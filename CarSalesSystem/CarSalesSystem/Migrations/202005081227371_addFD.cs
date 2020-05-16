namespace CarSalesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileDatas", "Car_Id", c => c.Int());
            CreateIndex("dbo.FileDatas", "Car_Id");
            AddForeignKey("dbo.FileDatas", "Car_Id", "dbo.Cars", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileDatas", "Car_Id", "dbo.Cars");
            DropIndex("dbo.FileDatas", new[] { "Car_Id" });
            DropColumn("dbo.FileDatas", "Car_Id");
        }
    }
}
