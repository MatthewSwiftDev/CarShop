namespace CarSalesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsersId = c.Int(nullable: false),
                        Title = c.String(),
                        Price = c.Long(nullable: false),
                        Year = c.String(),
                        Mileage = c.Int(nullable: false),
                        BodyType = c.String(),
                        Colour = c.String(),
                        Engine = c.String(),
                        DriveUnit = c.String(),
                        Transmission = c.String(),
                        Description = c.String(),
                        PhoneNumber = c.String(),
                        PlaceOfSale = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "User_Id", "dbo.Users");
            DropIndex("dbo.Cars", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Cars");
        }
    }
}
