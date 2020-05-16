﻿namespace CarSalesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newEr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Image");
        }
    }
}
