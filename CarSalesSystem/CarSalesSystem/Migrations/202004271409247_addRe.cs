namespace CarSalesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "User_Id", "dbo.Users");
            DropIndex("dbo.Cars", new[] { "User_Id" });
            RenameColumn(table: "dbo.Cars", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Cars", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "UserId");
            AddForeignKey("dbo.Cars", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "UserId", "dbo.Users");
            DropIndex("dbo.Cars", new[] { "UserId" });
            AlterColumn("dbo.Cars", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Cars", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Cars", "User_Id");
            AddForeignKey("dbo.Cars", "User_Id", "dbo.Users", "Id");
        }
    }
}
