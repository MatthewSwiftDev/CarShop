namespace CarSalesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSalenew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        IDuser = c.Int(nullable: false),
                        IDcar = c.Int(nullable: false),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sales");
        }
    }
}
