namespace CarSalesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileDatas", "userI", c => c.Int(nullable: false));
            DropColumn("dbo.FileDatas", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileDatas", "userId", c => c.Int(nullable: false));
            DropColumn("dbo.FileDatas", "userI");
        }
    }
}
