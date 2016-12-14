namespace PVT.Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOrder : DbMigration
    {
        public override void Up()
        {
            this.RenameColumn(table: "dbo.Orders", name: "Created", newName: "DateAdded");
            this.AddColumn("dbo.Orders", "UserName", c => c.String());
            this.AddColumn("dbo.Orders", "PhoneNumber", c => c.String());
            this.AlterColumn("dbo.Orders", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            this.AlterColumn("dbo.Orders", "DateAdded", c => c.DateTime(precision: 7, storeType: "datetime2"));
            this.DropColumn("dbo.Orders", "PhoneNumber");
            this.DropColumn("dbo.Orders", "UserName");
            this.RenameColumn(table: "dbo.Orders", name: "DateAdded", newName: "Created");
        }
    }
}
