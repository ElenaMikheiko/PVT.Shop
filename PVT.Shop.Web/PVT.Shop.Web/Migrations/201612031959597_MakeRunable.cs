namespace PVT.Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRunable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserName", c => c.String());
            AddColumn("dbo.Orders", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PhoneNumber");
            DropColumn("dbo.Orders", "UserName");
        }
    }
}
